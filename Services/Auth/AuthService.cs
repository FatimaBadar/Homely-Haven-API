using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Ecommerce_API.Data;
using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce_API.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }
        public async Task<ResponseVM<RegisteredUserDto>> Register(UserRegisterDto userDto)
        {
            //check if email already exists
            var userExists = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == userDto.Email);
            if (userExists != null)
            {
                return new ResponseVM<RegisteredUserDto>("409", "User already exists");
            }

            var newUser = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = "",
                Phone = userDto.Phone,
                Address = userDto.Address,
                isAdmin = false
            };
            var hashedPassword = new PasswordHasher<User>().HashPassword(newUser, userDto.Password);
            newUser.PasswordHash = hashedPassword;

            // Save the new user to the database
            _appDbContext.Users.Add(newUser);
            await _appDbContext.SaveChangesAsync();

            // Return the created user
            var loggedinUser = new RegisteredUserDto
            {
                Email = userDto.Email,
                Password = userDto.Password,
                isAdmin = false
            };

            return new ResponseVM<RegisteredUserDto>("200", "User created successfully", loggedinUser);
        }

        public async Task<ResponseVM<AuthDto>> Login(UserLoginDto userDto)
        {
            // Check if the user exists
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (user == null)
            {
                return new ResponseVM<AuthDto>("404", "No User found");
            }

            // Verify the password
            var verifyPassqord = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDto.Password);
            if (verifyPassqord == PasswordVerificationResult.Failed)
            {
                return new ResponseVM<AuthDto>("401", "Incorrect password");
            }
            // Generate a JWT token
            string token = GenerateJWT(user);

            AuthDto authDto = await CreateAndGetNewRefreshToken(user, token);

            return new ResponseVM<AuthDto>("200", "Login successful", authDto);
        }

        private async Task<AuthDto> CreateAndGetNewRefreshToken(User user, string token)
        {
            return new AuthDto
            {
                AccessToken = token,
                RefreshToken = await GenerateAndSaveRefreshToken(user)
            };
        }

        private string GenerateJWT(User user)
        {
            // Implement JWT generation logic here
            //claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.isAdmin ? "Admin" : "User")
            };
            //secret ket
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")));

            //signing credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            //token descriptor
            var tokenDescriptor = new JwtSecurityToken
            (
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        private async Task<string> GenerateAndSaveRefreshToken(User user)
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            var refreshToken = Convert.ToBase64String(randomNumber);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _appDbContext.SaveChangesAsync();
            return user.RefreshToken;
        }

        public async Task<ResponseVM<AuthDto>> GetRefreshToken(RefreshTokenDto userDto)
        {
            //validate refresh token
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userDto.UserId);
            if (user == null || user.RefreshToken != userDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new ResponseVM<AuthDto>("401", "Invalid refresh token");
            }

            //if expired, get a new refresh token
            var token = await CreateAndGetNewRefreshToken(user, userDto.RefreshToken); ;
         
            return new ResponseVM<AuthDto>("200", "Token refreshed successfully", token);
        }

    }
}
