using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bidhub.Models
{
    public class Auctioneer
    {
        [Key]
        public int AuctioneerId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string? PhotoUrl { get; set; }
        public string Role { get; set; }
        public int StaffNo { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();


    }
}
