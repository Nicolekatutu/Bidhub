using System.ComponentModel.DataAnnotations;
using Bidhub.Validation;

namespace Bidhub.Dto
{
    public class BidderRegisterDto
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        public required string LastName { get; set; }

        //[Required]  
        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Username can only contain letters or digits.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [PasswordStrength]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Physical Address is required")]
        public required string PhysicalAddress { get; set; }
        public string CompanyUrl { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone number must be exactly 9 digits")]
        public required string PhoneNumber { get; set; }
    }
}
