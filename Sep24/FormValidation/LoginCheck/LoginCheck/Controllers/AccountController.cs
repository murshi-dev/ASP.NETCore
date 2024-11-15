using Microsoft.AspNetCore.Mvc;
using LoginCheck.Models;
namespace LoginCheck.Controllers
{
	public class AccountController : Controller
	{
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(Login model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("WelcomePage");//create this page/method
			}
			return View();
		}
		public ActionResult WelcomePage()
		{
			return View();
		}
		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Register(Register model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("HomePage");
			}
			return View();
		}
		public ActionResult HomePage()
		{
			return View();
		}
	}
}
