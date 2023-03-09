using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FormsValidation.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }

        [RegularExpression(@"^[789]\d{9}$",ErrorMessage = "Please Enter Correct Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Accept Terms")]
        public bool Terms { get; set; }
    }
}
