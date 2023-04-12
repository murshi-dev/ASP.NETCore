using Microsoft.EntityFrameworkCore;
using WebAPIDemonstration.Model;

namespace WebAPIDemonstration.Data
{
	public class ContactsAPIDBContext:DbContext
	{
		//constructor
		public ContactsAPIDBContext(DbContextOptions options) : base(options) { }
		
		public DbSet<Contact> Contacts { get; set; }
	}
}
