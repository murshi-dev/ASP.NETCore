using LoginValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginValidation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Welcome Page");
            }
            return View();
        }
        public IActionResult WelcomePage()
        {
            return View();
        }
    }
}
