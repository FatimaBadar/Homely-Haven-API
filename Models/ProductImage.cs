using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce_API.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //[JsonIgnore]
        public Product Product { get; set; } //navigation property
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
