using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce_API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        //[JsonIgnore]
        public required Order Order { get; set; } //navigation property
        //[JsonIgnore]
        public int ProductId { get; set; }
        public required Product Product { get; set; } //navigation property
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; } 
    }
}
