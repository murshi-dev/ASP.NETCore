using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormsValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormsValidation.Controllers
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
            //Traditional if..else
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Please Enter Name");
            //}
            //if (string.IsNullOrEmpty(model.Username))
            //{
            //    ModelState.AddModelError("Username", "Please Enter Username");
            //}

            //
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