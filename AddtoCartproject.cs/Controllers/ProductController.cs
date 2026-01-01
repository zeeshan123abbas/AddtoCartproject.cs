using AddtoCartproject.cs.Helpers;
using AddtoCartproject.cs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddtoCartproject.cs.Controllers
{
    public class ProductController : Controller
    {
        private readonly DBModel obj;

        public ProductController(DBModel obj)
        {
            this.obj = obj;
        }
        public IActionResult Index()
        {
            var products = obj.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Handle form post
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                obj.Products.Add(product);
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Add product to cart (Session)
        public IActionResult AddToCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart")
                       ?? new List<CartItem>();

            var product = obj.Products.Find(id);
            if (product == null)
                return NotFound();

            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index", "Cart");
        }
    }
}

