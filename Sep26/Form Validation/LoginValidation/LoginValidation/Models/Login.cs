using System.ComponentModel.DataAnnotations;

namespace LoginValidation.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(10, MinimumLength = 6,
            ErrorMessage = "Password must be between 6 to 10 chars")]
        public string Password { get; set; }
    }
}
