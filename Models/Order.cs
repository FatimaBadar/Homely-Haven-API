using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required DateTime OrderDate { get; set; }
        public required decimal TotalAmount { get; set; }
        public required string Status { get; set; } // e.g., "Pending", "Shipped", "Delivered"
        public required string ShippingAddress { get; set; }
        public required string PaymentMethod { get; set; } // e.g., "Credit Card", "PayPal"
        public required List<OrderItem> OrderItems { get; set; }

        public required int UserId { get; set; }
        public required User User { get; set; }

    }
}
