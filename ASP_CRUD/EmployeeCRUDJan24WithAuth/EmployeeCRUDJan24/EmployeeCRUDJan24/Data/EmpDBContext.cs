//this is dbcontext file  - acts as a bridge between the EF Core
//and the database
using EmployeeCRUDJan24.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDJan24.Data
{
	//inherit the DbContext class from EntityFrameworkCore package
	public class EmpDBContext:IdentityDbContext
	{
		//initialise the constructor 
		public EmpDBContext(DbContextOptions options) : base(options)
		{ }
		//set the model/table name
		public DbSet<Employee> Employees { get; set; }
	}
}
