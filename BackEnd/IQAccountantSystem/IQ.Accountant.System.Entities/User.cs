using IQ.Accountant.System.Entities.GR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IQ.Accountant.System.Entities
{
    [Table("USER")]
    public class User: BaseEntity
    {
        [Column("USER_NAME")]
        public string UserName { get; set; }
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("IMAGE_ID")]
        public int? ImageId { get; set; }
        public ImageVideo ImageVideo { get; set; }
    }
}
