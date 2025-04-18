using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public required int Stock { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public List<ProductImage>? ProductImages { get; set; }

    }
}
