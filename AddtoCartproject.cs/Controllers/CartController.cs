using AddtoCartproject.cs.Helpers;
using AddtoCartproject.cs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddtoCartproject.cs.Controllers
{
    public class CartController : Controller
    {

        private readonly DBModel obj;

        public CartController(DBModel obj)
        {
            this.obj = obj;
        }
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart")
                       ?? new List<CartItem>();
            ViewBag.Count = cart.Sum(x => x.Quantity);
            return View(cart);
        }

        public IActionResult Increase(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
                item.Quantity++;
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Decrease(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                    cart.Remove(item);
            }
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
                cart.Remove(item);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart")
                       ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            if (cart == null || !cart.Any())
                return RedirectToAction("Index");

            var order = new Order
            {
                UserId = 1,
                OrderDate = DateTime.Now,
                TotalAmount = cart.Sum(x => x.Price * x.Quantity),
                OrderItems = cart.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList()
            };

            obj.My_order.Add(order);
            obj.SaveChanges();

            HttpContext.Session.Remove("Cart");
            return View("OrderSuccess");
        }
        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
