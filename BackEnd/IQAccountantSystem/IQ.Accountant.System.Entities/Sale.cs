using IQ.Accountant.System.Entities.GR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IQ.Accountant.System.Entities
{
    [Table("SALE")]
    public class Sale:BaseEntity
    {
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }
        [Column("QYANTITY")]
        public int Quantity { get; set; }
        public Product Product { get; set; }

        
    }
}
