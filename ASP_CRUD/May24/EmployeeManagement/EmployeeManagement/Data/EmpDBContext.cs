using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace EmployeeManagement.Data
{
    public class EmpDBContext:IdentityDbContext
    {
        public EmpDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeManagement.Models.UpdateEmployee> UpdateEmployee { get; set; } = default!;
    }
}
