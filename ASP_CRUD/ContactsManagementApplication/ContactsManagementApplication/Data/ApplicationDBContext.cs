using ContactsManagementApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactsManagementApplication.Data
{
	public class ApplicationDBContext : IdentityDbContext
	{
		public ApplicationDBContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<ContactsEntity> ContactsInfo { get; set; }
	}
}
