using Microsoft.AspNetCore.Mvc;

using DemoMVC1.Models;
namespace DemoMVC1.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PersonInfo()
        {
            Person person = new Person();
            person.PersonName = "Jane";
            person.PersonAge= 30;
            person.PersonLocation = "Penang";

            return View(person);
        }
    }
}
