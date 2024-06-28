using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    //PersonController inherits from Controller class
    public class PersonController : Controller
    {
        //IActionResult - interface --here it rerepsents
        //the result of an action method - Index()
        public IActionResult Index()
        {
            //creating object for the Person class
            Person person = new Person();
            //assign values to the properties
            person.Id = 1001;
            person.Name = "Jane";
            person.Location = "Penang";
            person.Age= 30;
            person.ContactNumber = "01234567";
            //return the object person
            return View(person);
        }
    }
}
