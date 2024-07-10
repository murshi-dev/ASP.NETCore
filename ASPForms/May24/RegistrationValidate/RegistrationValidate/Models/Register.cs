using System.ComponentModel.DataAnnotations;

namespace RegistrationValidate.Models
{
    public class Register
    {
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password Required")]
        [StringLength(5,MinimumLength =3,ErrorMessage ="Password must be 3 to 5 literals")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("Password",ErrorMessage ="Passwords does not match")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Contact Number Required")]
        [RegularExpression(@"^01[0-9]-[0-9]{7}$", ErrorMessage = "Invalid Contact Number")]
        public string Contact { get; set; }

    }
}
