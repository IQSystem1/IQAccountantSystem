using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Services.IServices
{
    public interface ISaleService
    {
        Sale Insert(SaleProductDTO saleProduct);
        IEnumerable<SaleDTO> GetSales(PaginationInfo paginationInfo);
        TableCount GetCount();
        IEnumerable<SaleDTO> SearchByCode(string code);

    }
}
