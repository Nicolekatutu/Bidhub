using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bidhub.Models
{
    public class Bidders
    {
        [Key]
        public int BidderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string CompanyUrl { get; set; }

    }
}
