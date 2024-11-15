using System.ComponentModel.DataAnnotations;

namespace LoginCheck.Models
{
	public class Register
	{
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email {  get; set; }
       
        [Required(ErrorMessage = "Password Required")]
        [MaxLength(5,ErrorMessage ="Password must not be more than 5 chars")]
        [MinLength(3, ErrorMessage = "Password must be atleast 3 chars")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("Password",ErrorMessage ="Passwords does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Contact Required")]
        [RegularExpression(@"^01[0-9]-[0-9]{7}$",ErrorMessage ="Invalid Contact Number")]
        public string Contact {  get; set; }

	}
}
