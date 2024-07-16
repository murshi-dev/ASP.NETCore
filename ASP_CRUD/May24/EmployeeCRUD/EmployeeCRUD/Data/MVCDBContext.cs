using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EmployeeCRUD.Models;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace EmployeeCRUD.Data
{
    public class MVCDBContext:IdentityDbContext
    {
        public MVCDBContext(DbContextOptions options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCRUD.Models.UpdateEmployeeModel> UpdateEmployeeModel { get; set; } = default!;
    
    }
}
