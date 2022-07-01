using IQ.Accountant.System.Entities.GR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQ.Accountant.System.Entities
{
    [Table("PRODUCT")]
    public class Product:BaseEntity
    {
        [Column("PRODUCT_NAME")]
        [Required]
        public string ProductName { get; set; }
        [Column("PRODUCT_CODE")]
        public string ProductCode { get; set; }
        [Column("PRODUCT_IQ_CODE")]
        public string ProductIqCode { get; set; }
        [Column("PRODUCT_UNIT")]
        [Required]
        public string ProductUnit { get; set; }
        [Column("PRODUCT_PRICE")]
        [Required]
        public float ProductPrice { get; set; }
        [Column("PRODUCT_TAX")]
        public float? ProductTax { get; set; }
        [Column("PRODUCT_NOTE")]
        public string ProductNote { get; set; }

        public ICollection<ProductImageVideo> productImages { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
