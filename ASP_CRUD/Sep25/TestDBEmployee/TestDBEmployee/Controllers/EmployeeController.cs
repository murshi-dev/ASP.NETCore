using Microsoft.AspNetCore.Mvc;
using TestDBEmployee.Data;
using TestDBEmployee.Models;

namespace TestDBEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        //link the DBContext file
        private EmpContext empContext;
        //initialise constructor
        public EmployeeController(EmpContext empContext)
        {
            this.empContext = empContext;
        }
        public EmpContext context { get; }

        [HttpGet]//view the add form
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]//save the data from the add form to the table
        public IActionResult Add(AddEmployee addRequest)
        {
            //create object for the Add Employee --retrieve form data
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addRequest.Name,
                Email = addRequest.Email,
                DateOfJoin = addRequest.DateOfJoin,
                Designation = addRequest.Designation,
                Salary = addRequest.Salary
            };
            //use the Add() to add the data
            empContext.Employees.Add(employee);
            //SaveChange() to save the data
            empContext.SaveChanges();
            //after adding records, display the Index page
            return RedirectToAction("Index");
        }
        //Display Records from the table
        [HttpGet]
        public IActionResult Index()
        {
            var employees = empContext.Employees.ToList();
            return View(employees);
        }
        //edit process --step 1 
        //display data based on id selcted
        [HttpGet]
        public IActionResult View(Guid id)
        {
            //search based on the id entered
            var employee = empContext.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfJoin = employee.DateOfJoin,
                    Designation = employee.Designation,
                    Salary = employee.Salary
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
        //edit process --step 2 
        //edit the data -- replacing old data with new data
        [HttpPost]
        public IActionResult View(UpdateEmployee model, string action)
        {
            if (action == "Update")
            {
                var employee = empContext.Employees.Find(model.Id);
                if (employee != null)
                {
                    //replace old data with new data
                    employee.Name = model.Name;
                    employee.Email = model.Email;
                    employee.DateOfJoin = model.DateOfJoin;
                    employee.Designation = model.Designation;
                    employee.Salary = model.Salary;
                    empContext.SaveChanges();
                }
            }
            else if(action =="Delete")
            {
                var employee = empContext.Employees.Find(model.Id);
                if (employee != null)
                {
                    empContext.Employees.Remove(employee);
                    empContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
