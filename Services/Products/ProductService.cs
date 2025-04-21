using Ecommerce_API.Data;
using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services.Products
{
    public class ProductService : IProductService
    {
        AppDbContext _appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CheckProductById(int productId)
        {
            var product = await _appDbContext.Products.FindAsync(productId);
            if (product == null)
            {
                return false;
            }
            return true;
        }

        //move to diff service
        public async Task<ResponseVM<List<ProductImageDto>>> GetProductImagesByProductId(int productId)
        {
            var product = GetProductDetailsById(productId).Result.ResponseData;
            if(product == null)
            {
                return new ResponseVM<List<ProductImageDto>>("400", "Product not found");
            }

            var images = await _appDbContext.ProductImages
                .Where(x => x.ProductId == productId).ToListAsync();

            if (images == null || images.Count == 0)
            {
                return new ResponseVM<List<ProductImageDto>>("404", "No images found for this product");
            }

            var imageDto = images.Select(image => new ProductImageDto
            {
                Imageurl = image.ImageUrl,
                isMain = image.IsMain,
            }).ToList();            
            
            return new ResponseVM<List<ProductImageDto>>("200", "Fetched product's images", imageDto);
        }
        
        public async Task<ResponseVM<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .ToListAsync();

            if(products == null || products.Count == 0)
            {
                return new ResponseVM<IEnumerable<ProductDto>>("404", "No products found");
            }

            var productDto = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                //CategoryId = p.CategoryId,
                Category = new CategoryDto
                {
                    Name = p.Category.Name,
                    Description = p.Category.Description
                },
                ProductImages = p.ProductImages.Select(i => new ProductImageDto
                {
                    Imageurl = i.ImageUrl,
                    isMain = i.IsMain,
                }).ToList()
            });

            //var productDto = products
            //    .Select(p => new ProductDto
            //    {
            //        //Id = p.Id,
            //        Name = p.Name,
            //        Description = p.Description,
            //        Price = p.Price,
            //        Stock = p.Stock,
            //        CategoryName = GetProductCategory(p.Id).Result.ResponseData.Name,
            //        CategoryDescription = GetProductCategory(p.Id).Result.ResponseData.Description,
            //        ProductImages = GetProductImagesByProductId(p.Id).Result.ResponseData,
            //    });

            return new ResponseVM<IEnumerable<ProductDto>>("200", "Products found", productDto);
        }

        public async Task<ResponseVM<Product>> GetProductDetailsById(int id)
        {
            var product = await _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
            //FindAsync(productId);
            if (product == null)
            {
                return new ResponseVM<Product>("404", "No product found by that id");
            }
            return new ResponseVM<Product>("200", "Product fetched succesfully", product);
        }

        public async Task<ResponseVM<Product>> AddProduct(ProductDto product)
        {
            //if (product == null)
            //{
            //    return new ResponseVM<Product>("400", "Product cannot be null");
            //}

            //_appDbContext.Products.Add(product);
            //await _appDbContext.SaveChangesAsync();

            //var newProduct = new ProductDto
            //{
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    Stock = product.Stock,
            //    Category = new CategoryDto
            //    {
            //        Name = product.Category.Name,
            //        Description = product.Category.Description
            //    },
            //    ProductImages = product.ProductImages.Select(i => new ProductImageDto
            //    {
            //        Imageurl = i.ImageUrl,
            //        isMain = i.IsMain,
            //    }).ToList()
            //};
            //return new ResponseVM<Product>("200", "Product added successfully");
            throw new NotImplementedException();

        }

        public Task<ResponseVM<ProductDto>> UpdateProduct(int id, Product newProductDetails)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseVM<bool>> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
