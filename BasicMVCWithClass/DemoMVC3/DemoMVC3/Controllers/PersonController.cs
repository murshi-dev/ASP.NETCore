using DemoMVC3.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC3.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PersonInfo()
        {

            ViewPerson myperson = new ViewPerson();
            myperson.Persons = GetPersons();
            return View(myperson);
        }
        public List<Person> GetPersons()//create objects and group them in a List 
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { PersonName = "Amy", PersonAge = 30, PersonLocation = "GeorgeTown" });
            persons.Add(new Person { PersonName = "Jane", PersonAge = 40, PersonLocation = "Batu Kawan" });
            persons.Add(new Person { PersonName = "John", PersonAge = 50, PersonLocation = "bayan Lepas" });
            return persons;
        }


    }
}
