using System.ComponentModel.DataAnnotations;

namespace TranspoJo.DTOs
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+{}:;<>.,?]).{6,}$",
          ErrorMessage = "Password must be at least 6 characters long, contain at least one uppercase letter, one number, and one special character (!@#$ etc).")]
        public string Password { get; set; }
    }

}
