using System.ComponentModel.DataAnnotations;

namespace Bidhub.Dto
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StaffNo { get; set; }
        public string Email { get; set; }
        public string CompanyUrl { get; set; }
        public string Role { get; set; }
        public IFormFile? Photo { get; set; } // for file uploads
    }
}
