using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce_API.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //[JsonIgnore]
        public required Product Product { get; set; } //navigation property

        public required string ImageUrl { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
