using EmployeeCRUDJan24.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//inject the dbcontext (empdbcontext) in to this program.cs file
builder.Services.AddDbContext<EmpDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmpConnectionString")));
//Note!EmpConnectionString is the connection string that will help
//to connect with the exact database in MSSQL

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();