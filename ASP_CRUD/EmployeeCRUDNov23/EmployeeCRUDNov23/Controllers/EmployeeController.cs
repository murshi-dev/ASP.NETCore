using EmployeeCRUDNov23.Data;
using EmployeeCRUDNov23.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDNov23.Controllers
{
	public class EmployeeController : Controller
	{
		//connect the dbcontext here
		private MVCDBContext mvcdbcontext;
		public EmployeeController(MVCDBContext mvcdbcontext) 
		{ 
			this.mvcdbcontext=mvcdbcontext;
		}
		//to retrieve records of type MvcDBContext
		public MVCDBContext MvcDBContext { get; }
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		//logic to add records into database
		public IActionResult Add(AddEmployee addEmployeeRequest)
		{
			var employee = new Employee()
			{
				Id = Guid.NewGuid(),
				Name = addEmployeeRequest.Name,
				Email = addEmployeeRequest.Email,
				DateOfJoin = addEmployeeRequest.DateOfJoin,
				Designation = addEmployeeRequest.Designation,
				Salary = addEmployeeRequest.Salary
			};
			//save this data in db
			mvcdbcontext.Employees.Add(employee);
			mvcdbcontext.SaveChanges();
			//after saving the data redirect the page to home/index
			return RedirectToAction("Index");

		}
		[HttpGet]
		//method to view records from db to asp.net application
		public IActionResult Index()
		{
			var employees=mvcdbcontext.Employees.ToList();
			return View(employees);
		}
		//update
		[HttpGet]
		public IActionResult View(Guid id) 
		{
			//find the record related to the id selected - use FirstorDefault method
			var employee = mvcdbcontext.Employees.FirstOrDefault(x => x.Id == id);
			//check if the record exist
			if (employee != null) 
			{
				//fill the form with the retrieved data
				var viewModel = new UpdateEmployee()
				{
					Id = employee.Id,
					Name = employee.Name,
					Email = employee.Email,
					DateOfJoin = employee.DateOfJoin,
					Designation = employee.Designation,
					Salary = employee.Salary
				};
				return View("View", viewModel);
			}
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult View(UpdateEmployee model)
		{
			//use Find method to select the record base don the Id
			var employee = mvcdbcontext.Employees.Find(model.Id);
			if(employee != null) 
			{
				//proceed with the changes
				employee.Name= model.Name;
				employee.Email= model.Email;
				employee.DateOfJoin= model.DateOfJoin;
				employee.Designation= model.Designation;
				employee.Salary= model.Salary;
				//save the changes
				mvcdbcontext.SaveChanges();
				//after update and save display index page
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		//delete
		[HttpPost]
		public IActionResult Delete(UpdateEmployee model)
		{
			var employee = mvcdbcontext.Employees.Find(model.Id);
			if(employee != null) 
			{ 
				mvcdbcontext.Employees.Remove(employee);
				mvcdbcontext.SaveChanges();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		
	}
}
