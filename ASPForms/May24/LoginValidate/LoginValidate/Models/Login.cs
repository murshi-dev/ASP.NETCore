using System.ComponentModel.DataAnnotations;

namespace LoginValidate.Models
{
	public class Login
	{
		[Required(ErrorMessage="Email Required")]
		[EmailAddress(ErrorMessage ="Invalid Email Address")]
		public string Email { get; set; }
		
		[Required(ErrorMessage ="Password Required")]
		[StringLength(5,MinimumLength =3,ErrorMessage ="Password must be between 3 to 5")]
		public string Password { get; set; }

	}
}
