using System.ComponentModel.DataAnnotations;

namespace FormValidation.Models
{
	public class RegistrationView
	{
		[Required(ErrorMessage = "Please enter email")]
		[RegularExpression(@"^[^\s]+@[^\s]+\.[^\s]{3}$",ErrorMessage = "Enter valid email")]
		public string Email {  get; set; }

		[Required(ErrorMessage = "Please enter password")]
		[MaxLength(5,ErrorMessage ="Max upto 5 charecters")]
		[MinLength(3, ErrorMessage = "Min upto 3 charecters")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Please enter confirm password")]
		[Compare("Password",ErrorMessage ="Password does not match")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Please enter contact number")]
		[RegularExpression(@"^01[0-9]-[0-9]{7}$", ErrorMessage = "Enter valid contact")]
		public string Contact {  get; set; }
	}
}
