using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bidhub.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ReasonForAuction { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNo { get; set; }
        public double ReservePrice { get; set; }
        public string Location { get; set; }

        
        [ForeignKey("Auctioneer")]
        public int AuctioneerId { get; set; }
        public Auctioneer Auctioneer { get; set; }

        public ICollection<ProductDocument> ProductDocuments { get; set; } = new List<ProductDocument>();
        public ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();
        public ICollection<BidDates> BidDetails { get; set; } = new List<BidDates>();
        public ICollection<BViewing> BViewings { get; set; }
    }
}
