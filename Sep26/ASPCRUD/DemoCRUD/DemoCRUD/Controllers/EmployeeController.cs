using DemoCRUD.Data;
using DemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DemoCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private DemoContext democontext;
        public EmployeeController(DemoContext demoContext)
        {
            this.democontext = demoContext;
        }
        public DemoContext context { get; }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddEmployeeModel addRequest)
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
            democontext.Employees.Add(employee);
            democontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = democontext.Employees.ToList();
            return View(employees);
        }
    }
}
