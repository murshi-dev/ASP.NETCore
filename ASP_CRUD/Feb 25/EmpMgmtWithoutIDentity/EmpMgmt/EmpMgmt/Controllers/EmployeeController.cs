using EmpMgmt.Data;
using EmpMgmt.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.Controllers
{
    public class EmployeeController : Controller
    {
        private MVCDBContext mvcdbcontext;
        public EmployeeController(MVCDBContext mvcdbcontext)
        {
            this.mvcdbcontext=mvcdbcontext;
        }
        public MVCDBContext context { get; }
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
                DOJ = addRequest.DOJ,
                Designation = addRequest.Designation,
                Salary = addRequest.Salary
            };
            mvcdbcontext.Employees.Add(employee);
            mvcdbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = mvcdbcontext.Employees.ToList();
            return View(employees);
        }


        [HttpGet]
        public IActionResult View(Guid id)
        {
            var employee = mvcdbcontext.Employees.FirstOrDefault(x=>x.Id == id);
            if(employee != null)
            {
                var viewModel = new UpdateEmployeeModel()
                {
                    Id = id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DOJ = employee.DOJ,
                    Designation = employee.Designation,
                    Salary = employee.Salary
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult View(UpdateEmployeeModel model,string action)
        {
            if (action == "Update")
            {
                var employee = mvcdbcontext.Employees.Find(model.Id);
                if (employee != null)
                {
                    employee.Name = model.Name;
                    employee.Email = model.Email;
                    employee.DOJ = model.DOJ;
                    employee.Designation = model.Designation;
                    employee.Salary = model.Salary;

                    mvcdbcontext.SaveChanges();
                }
            }
            else if (action == "Delete")
            {
                var employee = mvcdbcontext.Employees.Find(model.Id);
                if (employee != null)
                {
                    mvcdbcontext.Employees.Remove(employee);

                    mvcdbcontext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
