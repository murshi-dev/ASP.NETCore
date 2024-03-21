using EmployeeCRUDJan24.Data;
using EmployeeCRUDJan24.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeCRUDJan24.Controllers
{
	public class EmployeeController : Controller
	{

		//specify the dbcontext here
		private EmpDBContext empDBContext;
		public EmployeeController(EmpDBContext empDBContext)
		{
			this.empDBContext = empDBContext;
		}
		public EmpDBContext EMPDBContext { get; }

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		//method to save data entered in 'add form' to the table in database
		public IActionResult Add(AddEmployeeModel addEmployeeRequest)
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
			//meaning all the data from the form has been retrieved
			//and stored in the above variables
			//use the db context and db context name to call the Add method and 
			//pass the employee object inside
			empDBContext.Employees.Add(employee);
			//save the changes
			empDBContext.SaveChanges();
			//after saving the dat in database, display the view page
			return RedirectToAction("Index");

		}
		//add the view
		[HttpGet]
		public IActionResult Index() 
		{
			var employees = empDBContext.Employees.ToList();
			return View(employees);
		}

		//action for the view method 
		[HttpGet]
		public IActionResult View(Guid id) 
		{
			//write codes to fetch data from db and fill in the'view' form
			var employee=empDBContext.Employees.FirstOrDefault(x => x.Id == id);
			//firstordefault is a method used to fetch records from db
			if(employee!=null)
			{
				var viewModel = new UpdateEmployeeModel()
				{
					Id = employee.Id,
					Name = employee.Name,
					Email = employee.Email,
					DateOfJoin = employee.DateOfJoin,
					Designation = employee.Designation,
					Salary = employee.Salary
				};//retrieve all data from db and store in 'viewModel' object
				return View("View", viewModel);
			}
			//after update go back to the index page
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult View(UpdateEmployeeModel model)
		{
			//search for the employee based on the id selected in the previuos page
			//use Find method
			var employee = empDBContext.Employees.Find(model.Id);
			if(employee!=null) 
			{ 
				//copy the model data(from the form - RHS) to the employee db object(LHS)
				employee.Name = model.Name;
				employee.Email = model.Email;
				employee.DateOfJoin = model.DateOfJoin;
				employee.Designation = model.Designation;	
				employee.Salary = model.Salary;
				//save the changes
				empDBContext.SaveChanges();
				//after saving the chnages go to index page
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult Delete(UpdateEmployeeModel model)
		{
			//find the data based on the id selected - use Find method
			var employee=empDBContext.Employees.Find(model.Id);
			if(employee!=null) 
			{ 
				//proceed with the delete process
				empDBContext.Employees.Remove(employee);
				//save the changes
				empDBContext.SaveChanges();
				//after deletion go back to index
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}
