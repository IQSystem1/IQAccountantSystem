using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Entities.DTO
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
        public string ProductCode { get; set; }
        public float ProductTax { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public string saleTime { get; set; }
        public int? PageSize { get; set; }

    }
}
