using System.ComponentModel.DataAnnotations;

namespace Bidhub.Dto
{
    public class AddRoleDto
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleDescription { get; set; }
    }
}
