using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Entities.DTO
{
    public class ProductDTO
    {
        public int productId { get; set; }
        public float productPrice { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public string productUnit { get; set; }
        public float? productTax { get; set; }
        public string productNote { get; set; }
        public string imageUrl { get; set; }
        public string videoUrl { get; set; }
        public string productIqCode { get; set; }

    }
}
