using System.ComponentModel.DataAnnotations;

namespace ketabSara.Models
{
    public class RegisterUserViewModel
    {

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "رمز ها همخوانی ندارد")]
        public string ConfirmPassword { get; set; }



    }
}
