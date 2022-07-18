using IQ.Accountant.System.Entities.GR.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQ.Accountant.System.Entities
{
    [Table("IMAGE_VIDEO")]
    public class ImageVideo:BaseEntity
    {
        [Column("URL")]
        public string Url { get; set; }
        public ICollection<ProductImageVideo> productImageVideos { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
