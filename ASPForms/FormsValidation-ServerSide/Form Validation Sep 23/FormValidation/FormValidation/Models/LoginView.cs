using System.ComponentModel.DataAnnotations;

namespace FormValidation.Models
{
	public class LoginView
	{
		[Required(ErrorMessage ="Please Enter Email")]
		public string Email {  get; set; }
		[Required(ErrorMessage = "Please Enter Password")]
		public string Password { get; set; }
	}
}
