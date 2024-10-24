using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bidhub.Models
{
    public class BViewing
    {
        [Key]
        public int ViewingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime viewingDate { get; set; }
        public string Email { get; set; }
    }
}
