using Microsoft.EntityFrameworkCore;

namespace AddtoCartproject.cs.Models
{
    public class DBModel:DbContext
    {
        public DBModel(DbContextOptions opt):base(opt)
        {
            
        }

        //public DbSet<CartItem> my_cart { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> My_order { get; set; }
        public DbSet<OrderItem> My_order_item { get; set; }
    }
}
