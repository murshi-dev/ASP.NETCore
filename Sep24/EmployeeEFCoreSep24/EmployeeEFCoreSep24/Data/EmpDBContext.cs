using Microsoft.EntityFrameworkCore;
using EmployeeEFCoreSep24.Models;

namespace EmployeeEFCoreSep24.Data
{
    public class EmpDBContext:DbContext
    {
        public EmpDBContext(DbContextOptions options):base(options) { }   
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeEFCoreSep24.Models.UpdateEmployeeModel> UpdateEmployeeModel { get; set; } = default!;
    }
}
