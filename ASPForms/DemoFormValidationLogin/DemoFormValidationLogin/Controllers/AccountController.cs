using Microsoft.AspNetCore.Mvc;
using DemoFormValidationLogin.Models;
namespace DemoFormValidationLogin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid) 
            
            {
                return RedirectToAction("Message");
            }
            return View();
        }
        public IActionResult Message()
        {
            return View();
        }

    }
}
