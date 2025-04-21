using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        //[JsonIgnore]
        public required Category Category { get; set; } //navigation prop
        //[JsonIgnore]
        public ICollection<ProductImage> ProductImages { get; set; } //navigation prop

    }
}
