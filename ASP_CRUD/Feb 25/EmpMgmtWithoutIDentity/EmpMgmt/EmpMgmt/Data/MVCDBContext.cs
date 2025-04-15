using EmpMgmt.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmt.Data
{
    public class MVCDBContext:DbContext
    {
        public MVCDBContext(DbContextOptions options):base(options) { }   

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpMgmt.Models.UpdateEmployeeModel> UpdateEmployeeModel { get; set; } = default!;
    }
}
