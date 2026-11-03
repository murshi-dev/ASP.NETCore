using System.ComponentModel.DataAnnotations;

namespace RegValidation.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Email Required")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(10, MinimumLength = 6,
            ErrorMessage = "Password must be between 6 to 10 chars")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Contact Required")]
        [RegularExpression(@"^01[0-9]-[0-9]{7}$",
            ErrorMessage = "Invalid Contact number")]
        public string Contact { get; set; }
    }
}
