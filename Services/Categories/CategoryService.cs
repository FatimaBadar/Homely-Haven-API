using Ecommerce_API.Data;
using Ecommerce_API.DTOs;
using Ecommerce_API.Services.Products;
using Ecommerce_API.View;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IProductService _productService;
        public CategoryService(AppDbContext appDbContext, IProductService productService)
        {
            _appDbContext = appDbContext;
            _productService = productService;
        }
        //public async Task<List<Category>> GetAllCategories()
        //{
        //    return await _appDbContext.Categories.ToListAsync();
        //}
        //public async Task<Category> AddCategory(Category category)
        //{
        //    _appDbContext.Categories.Add(category);
        //    await _appDbContext.SaveChangesAsync();
        //    return category;
        //}

        public async Task<ResponseVM<CategoryDto>> GetProductCategory(int productId)
        {
            //check if product by the id exixts
            var product = await _productService.GetProductDetailsById(productId);
            if (product == null)
            {
                return new ResponseVM<CategoryDto>("400", "Product not found");
            }

            var category = await _appDbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == product.ResponseData.Category.Id);

            var categoryDto = new CategoryDto
            {
                Name = category.Name,
                Description = category.Description
            };

            return new ResponseVM<CategoryDto>("200", "Fetched product's category", categoryDto);

        }
    }
}
