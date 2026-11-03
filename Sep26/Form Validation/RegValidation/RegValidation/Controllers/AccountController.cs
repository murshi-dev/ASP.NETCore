using Microsoft.AspNetCore.Mvc;
using RegValidation.Models;

public class AccountController : Controller
{
    // Display registration form
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    // Process registration form
    [HttpPost]
    public IActionResult Registration(RegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            // Process registration
            return RedirectToAction("Index");
        }

        return View(model);
    }
}