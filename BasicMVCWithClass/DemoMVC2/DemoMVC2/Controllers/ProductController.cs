using DemoMVC2.Models;
using Microsoft.AspNetCore.Mvc;


namespace DemoMVC2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductInfo()
        {
            Product product = new Product();
            product.PName = "Sneakers";
            product.PPrice = 399;
            product.PQuantity= 10;
            product.DiscountPercent = 20;
            product.VendorContact = 0123456789;
			return View(product);
		}
    }
}
