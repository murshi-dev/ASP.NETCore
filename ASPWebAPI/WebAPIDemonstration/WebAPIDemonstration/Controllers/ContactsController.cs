using Microsoft.AspNetCore.Mvc;
using WebAPIDemonstration.Data;
using WebAPIDemonstration.Model;

namespace WebAPIDemonstration.Controllers
{
	[ApiController]
	[Route("api/controller")]
	public class ContactsController : Controller
	{
		//constructor
		private readonly ContactsAPIDBContext dbContext;
		public ContactsController(ContactsAPIDBContext dbContext)
		{
			this.dbContext=dbContext;
		}
		//read data
		[HttpGet]
		public IActionResult GetContacts()
		{
			return Ok(dbContext.Contacts.ToList());
		}
		//create data
		[HttpPost]
		public IActionResult AddContact(AddContactRequest addContactRequest) 
		{
			var contact = new Contact()
			{
				Id = new Guid(),
				FullName = addContactRequest.FullName,
				Email = addContactRequest.Email,
				Phone = addContactRequest.Phone,
				Address = addContactRequest.Address
			};
			dbContext.Contacts.Add(contact);
			dbContext.SaveChanges();
			return Ok(contact);
		}
		//update data
		[HttpPut]
		[Route("{id:guid}")]
		public IActionResult UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest) 
		{
			var contact=dbContext.Contacts.Find(id);
			if(contact!=null) 
			{
			contact.FullName= updateContactRequest.FullName;
				contact.Email= updateContactRequest.Email;
				contact.Phone= updateContactRequest.Phone;
				contact.Address= updateContactRequest.Address;
				dbContext.SaveChanges();
				return Ok(contact);
			
			}
			return NotFound();
		}
		[HttpDelete]
		public IActionResult DeleteContact([FromRoute] Guid id) 
		{
			var contact = dbContext.Contacts.Find(id);
			if(contact!=null ) 
			{
				dbContext.Remove(contact);
				dbContext.SaveChanges();
				return Ok(contact);
			}
			return NotFound();
		}
	}
}
