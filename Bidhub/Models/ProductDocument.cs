using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bidhub.Models
{
    public class ProductDocument
    {
        [Key]
        public int DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentUrl { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
