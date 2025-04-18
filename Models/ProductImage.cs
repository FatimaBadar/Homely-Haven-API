using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_API.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }

        public required string ImageUrl { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
