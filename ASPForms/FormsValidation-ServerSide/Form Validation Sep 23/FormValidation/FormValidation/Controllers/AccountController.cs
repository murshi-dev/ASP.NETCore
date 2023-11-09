using FormValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormValidation.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		//redirect to a success page if user enters valid entries
		[HttpPost]
		public IActionResult Login(LoginView model) 
		{
			if (ModelState.IsValid) 
			{
				return RedirectToAction("Success");
			}
			return View();
		}
		//create a method for success
		public IActionResult Success()
		{
			return View();
		}
		public IActionResult Registration()
		{
			return View();
		}
		//redirect to login page if user enters valid entries in register
		[HttpPost]
		public IActionResult Registration(RegistrationView model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("Login");
			}
			return View();
		}
	}
}
