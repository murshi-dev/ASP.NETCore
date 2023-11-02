//create object for the Person model class and 
//provide value to the properties id name and location
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
	public class PersonController : Controller
	{
		public IActionResult Info()
		{
			//create object
			Person person = new Person();
			//using person object fill deatils of properties
			person.Id = 1001;
			person.Name = "Jane";
			person.Location = "Penang";
			//return this person object to view
			return View(person);
		}
	}
}
