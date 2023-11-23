//create DBContext class here and set the model names here
using EmployeeCRUDNov23.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDNov23.Data
{
	public class MVCDBContext:DbContext
	{
		//constructor
		public MVCDBContext(DbContextOptions options) : base(options) { }
		//specify model name
		public DbSet<Employee> Employees { get; set; }
	}
}
