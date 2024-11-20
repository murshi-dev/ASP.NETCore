using EmployeeEFCoreSep24.Data;
using EmployeeEFCoreSep24.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeEFCoreSep24.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private EmpDBContext empDBContext;
        public EmployeeController(EmpDBContext empDBContext)
        {
            this.empDBContext = empDBContext;
        }
        public EmpDBContext Empdbcontext { get; }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        //add/save data from Add form to the tables in DB
        [HttpPost]
        public ActionResult Add(AddEmployeeModel addRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addRequest.Name,
                Email = addRequest.Email,
                DateOfJoin = addRequest.DateOfJoin,
                Designation = addRequest.Designation,
                Salary = addRequest.Salary
            };
            empDBContext.Employees.Add(employee);
            empDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //retrieve tha data from tables in DB and display in the web app(Index page)
        [HttpGet]
        public ActionResult Index()
        {
            var employees = empDBContext.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult View(Guid id)
        {
            var employee = empDBContext.Employees.FirstOrDefault(x => x.Id == id);
            if(employee != null)
            {
                var viewModel = new UpdateEmployeeModel()
                {
                    Id=employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfJoin=employee.DateOfJoin,
                    Designation = employee.Designation,
                    Salary=employee.Salary
                };
                return View(viewModel);
            }
			return RedirectToAction("Index");
		}
        [HttpPost]
        public ActionResult View(UpdateEmployeeModel model, string action)
        {
            if (action == "Update")
            {
                var employee = empDBContext.Employees.Find(model.Id);
                if (employee != null)
                {
                    employee.Name = model.Name;
                    employee.Email = model.Email;
                    employee.DateOfJoin = model.DateOfJoin;
                    employee.Designation = model.Designation;
                    employee.Salary = model.Salary;
                    empDBContext.SaveChanges();
                }
            }
            else if (action == "Delete")
            {
                var employee = empDBContext.Employees.Find(model.Id);
                if (employee != null)
                {
                    empDBContext.Employees.Remove(employee);
                    empDBContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
		}
	}
}
