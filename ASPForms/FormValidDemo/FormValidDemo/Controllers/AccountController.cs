using FormValidDemo.Models;
using Microsoft.AspNetCore.Mvc;


namespace FormValidDemo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {

            if (ModelState.IsValid)
            {
                //TO DO:
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



