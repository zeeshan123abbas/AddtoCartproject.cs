using System.ComponentModel.DataAnnotations;

namespace AddtoCartproject.cs.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } // Primary Key
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
