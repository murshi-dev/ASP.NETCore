using Microsoft.EntityFrameworkCore;
using TestDBEmployee.Models;

namespace TestDBEmployee.Data
{
    public class EmpContext:DbContext//inherit DbContext
    {
        //constructor
        public EmpContext(DbContextOptions options):base(options) { }

        //create a constructoe with type Employee
        public DbSet<Employee> Employees { get; set; }
    }
}
