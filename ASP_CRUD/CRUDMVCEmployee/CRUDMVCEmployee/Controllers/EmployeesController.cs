using CRUDMVCEmployee.Data;
using CRUDMVCEmployee.Models;
using CRUDMVCEmployee.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVCEmployee.Controllers
{
    public class EmployeesController : Controller
    {
        private MVCDemoDBContext mvcDemoDBContext;

        public EmployeesController(MVCDemoDBContext mvcDemoDBContext)
        {
            this.mvcDemoDBContext = mvcDemoDBContext;
        }

        public MVCDemoDBContext MvcDemoDBContext { get; }


        [HttpGet]
        public IActionResult Index()
        {
            var employees=mvcDemoDBContext.Employees.ToList();

            return View(employees);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department


            };
           mvcDemoDBContext.Employees.Add(employee);
            mvcDemoDBContext.SaveChanges();
              return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult View(Guid id)
        {
            var employee = mvcDemoDBContext.Employees.FirstOrDefault(x => x.Id == id);

            if (employee!=null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                Email = employee.Email,
                Salary = employee.Salary,
                DateOfBirth = employee.DateOfBirth,
                Department = employee.Department
                };
                return View("View",viewModel);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]

        public IActionResult View(UpdateEmployeeViewModel model)
        {
            var employee = mvcDemoDBContext.Employees.Find(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;

                mvcDemoDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(UpdateEmployeeViewModel model)
        {
            var employee = mvcDemoDBContext.Employees.Find(model.Id);
            if (employee != null) 
            {
                mvcDemoDBContext.Employees.Remove(employee);
                mvcDemoDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
