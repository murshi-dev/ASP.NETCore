using EmpMgmt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmpMgmt.Data
{
    public class MVCDBContext:IdentityDbContext
    {
        public MVCDBContext(DbContextOptions options):base(options) { }   

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpMgmt.Models.UpdateEmployeeModel> UpdateEmployeeModel { get; set; } = default!;
    }
}
