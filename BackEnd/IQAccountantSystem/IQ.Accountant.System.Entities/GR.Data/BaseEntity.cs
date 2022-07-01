using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IQ.Accountant.System.Entities.GR.Data
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Int32 Id
        {
            get;
            set;
        }
        [Column("ADDED_DATA")]
        public DateTime AddedDate
        {
            get;
            set;
        }
        [Column("MODEFIED_DATA")]
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        [Column("IP_ADDRESS")]
        public string IPAddress
        {
            get;
            set;
        }
        [NotMapped]
        public string ErrorMessage { get; set; }


    }
}
