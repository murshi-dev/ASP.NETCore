using System.ComponentModel.DataAnnotations;

namespace FormValidDemo.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
		[RegularExpression("^[a-zA-Z]{7,10}$", ErrorMessage = "Min 7 and Max 10 is only allowed.")]
		public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }

        [RegularExpression(@"^[0][1][0-9]\d{7}$", ErrorMessage = "Please Enter Correct Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Accept Terms")]
        public bool Terms { get; set; }
    }

}
