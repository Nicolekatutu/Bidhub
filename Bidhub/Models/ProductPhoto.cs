using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bidhub.Models
{
    public class ProductPhoto
    {
        [Key]
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
