using DemoCRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace DemoCRUD.Data
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
