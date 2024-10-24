using System.ComponentModel.DataAnnotations;

namespace Bidhub.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? CompanyUrl { get; set; } 
        public string? Location { get; set; }
        public string? Status { get; set; }
        public DateTime? DateAdded { get; set; }

        public ICollection<Auctioneer> Auctioneers { get; set; } 
    }
}

