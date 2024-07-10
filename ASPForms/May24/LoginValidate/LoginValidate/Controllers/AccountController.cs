using Microsoft.AspNetCore.Mvc;
using LoginValidate.Models;
namespace LoginValidate.Controllers
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
