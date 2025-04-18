using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required Order Order { get; set; }

        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; } 
    }
}
