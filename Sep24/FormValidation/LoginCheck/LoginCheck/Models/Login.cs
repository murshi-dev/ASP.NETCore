using System.ComponentModel.DataAnnotations;
namespace LoginCheck.Models
{
	public class Login
	{
		//Data Annotations - help to validate the form controls
		
		[Required(ErrorMessage="Email Required")]
		[EmailAddress(ErrorMessage ="Invalid Email Address")]
		public string Email { get; set; }
		[Required(ErrorMessage="Password Required")]
		[StringLength(10,MinimumLength =6,ErrorMessage ="Password must be min 6 max 10 charecters")]
		public string Password { get; set; }
	}
}
