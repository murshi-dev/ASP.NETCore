using System.ComponentModel.DataAnnotations;
namespace DemoFormValidationLogin.Models
{
    public class LoginViewModel
    {

		[Required(ErrorMessage = "Please enter your name")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter your password")]
		public string Password { get; set; }

	}
}
