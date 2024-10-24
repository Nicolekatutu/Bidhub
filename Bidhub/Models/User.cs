using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bidhub.Models
{
    public class User: IdentityUser<Guid>
    {
        [Key]
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public  override string UserName { get; set; }
        public  required string Email { get; set; }
        public string Password { get; set; }
        public string  PhysicalAddress { get; set; }
        public  string PhoneNumber { get; set; }
        public bool IsVerified { get; set; }

        public ICollection<Bidders> Bidders { get; set; }
        public ICollection<BViewing> BViewings { get; set; }
        public ICollection<Auctioneer> Auctioneers { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }

    }
}
