using Ecommerce_API.DTOs;
using Ecommerce_API.Models;
using Ecommerce_API.View;

namespace Ecommerce_API.Services.Products
{
    public interface IProductService
    {
        Task<ResponseVM<IEnumerable<ProductDto>>> GetAllProducts();
        Task <bool> CheckProductById(int id);
        Task<ResponseVM<Product>> GetProductDetailsById(int id);
        Task<ResponseVM<Product>> AddProduct(ProductDto product);
        Task<ResponseVM<ProductDto>> UpdateProduct(int id, Product newProductDetails);
        Task<ResponseVM<bool>> DeleteProduct(int id);
        Task<ResponseVM<List<ProductImageDto>>> GetProductImagesByProductId(int productId);
    }
}
