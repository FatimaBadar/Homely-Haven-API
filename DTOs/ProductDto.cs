using Ecommerce_API.Models;

namespace Ecommerce_API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public CategoryDto Category { get; set; } 
        public List<ProductImageDto> ProductImages { get; set; }

    }

    public class ProductImageDto
    {
        public string Imageurl { get; set; }
        public bool isMain { get; set; }
    }
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}