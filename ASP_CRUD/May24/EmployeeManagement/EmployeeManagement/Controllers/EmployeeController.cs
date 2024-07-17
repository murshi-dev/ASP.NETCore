using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private EmpDBContext empcontext;
        public EmployeeController(EmpDBContext empcontext)
        {
            this.empcontext = empcontext;
        }
        public EmpDBContext context { get; }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddEmployee addRequest)
        {
            var employee = new Employee()
            {
                Id=Guid.NewGuid(),
                Name=addRequest.Name,
                Email=addRequest.Email,
                DateOfJoin=addRequest.DateOfJoin,
                Designation=addRequest.Designation,
                Salary=addRequest.Salary
            };
            empcontext.Employees.Add(employee);
            empcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees=empcontext.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult View(Guid id)
        {
            var employee=empcontext.Employees.FirstOrDefault(x=> x.Id==id);
            if(employee!=null)
            {
                var viewEmployee = new UpdateEmployee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfJoin = employee.DateOfJoin,
                    Designation = employee.Designation,
                    Salary = employee.Salary
                };
                return View(viewEmployee);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult View(UpdateEmployee model,string action)
        {
            if (action == "Update")
            {
                var employee = empcontext.Employees.Find(model.Id);
                if (employee != null)
                {
                    employee.Name = model.Name;
                    employee.Email = model.Email;
                    employee.DateOfJoin = model.DateOfJoin;
                    employee.Designation = model.Designation;
                    employee.Salary = model.Salary;
                    empcontext.SaveChanges();
                }
            }
            else if(action =="Delete")
            {
                var employee = empcontext.Employees.Find(model.Id);
                if (employee != null)
                {
                    empcontext.Employees.Remove(employee);
                    empcontext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }

}
