using System.ComponentModel.DataAnnotations;

namespace Bidhub.Dto
{
    public class AssignRoleDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
