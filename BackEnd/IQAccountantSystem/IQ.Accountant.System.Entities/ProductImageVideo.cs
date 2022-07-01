using IQ.Accountant.System.Entities.GR.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQ.Accountant.System.Entities
{
    [Table("PRODUCT_IMAGE_VIDEO")]
    public class ProductImageVideo:BaseEntity
    {
        [Column("IMAGE_ID")]
        public int ImageVideoId { get; set; }
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Column("IS_IMAGE")]
        public bool IsImage { get; set; }        
        public ImageVideo imageVideo { get; set; }
        public Product product { get; set; }
    }
}
