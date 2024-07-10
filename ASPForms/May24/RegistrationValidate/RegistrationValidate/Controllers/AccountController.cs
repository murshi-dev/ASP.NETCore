using Microsoft.AspNetCore.Mvc;
using RegistrationValidate.Models;
namespace RegistrationValidate.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("WelcomePage");
            }
            return View();
        }
        public IActionResult WelcomePage()
        {
            return View();
        }
    }
}
