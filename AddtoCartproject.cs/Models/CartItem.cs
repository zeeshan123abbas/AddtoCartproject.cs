using System.ComponentModel.DataAnnotations;

namespace AddtoCartproject.cs.Models
{
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}


