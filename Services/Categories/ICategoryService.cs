using Ecommerce_API.DTOs;
using Ecommerce_API.View;

namespace Ecommerce_API.Services.Categories
{
    public interface ICategoryService
    {
        Task<ResponseVM<CategoryDto>> GetProductCategory(int productId);
    }
}
