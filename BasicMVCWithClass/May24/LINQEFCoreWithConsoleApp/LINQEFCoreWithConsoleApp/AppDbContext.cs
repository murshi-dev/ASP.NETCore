//this file has the connection settings 
//between the Employee.cs file and the SQL Server
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication.ExtendedProtection;
public class AppDbContext: DbContext
{
    //create a dbset based on the Employee class
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=LAPTOP-HSE3065I\\SQLEXPRESS;database=EmpConsoleApp;" +
            "Trusted_connection=true;Integrated Security=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity=>
        {
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Id).ValueGeneratedOnAdd();
        });
    }
}