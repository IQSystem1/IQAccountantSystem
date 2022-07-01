using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Services.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> Get(PaginationInfo paginationInfo);
        IEnumerable<ProductDTO> Search(ProductDTO product = null);
        ProductDTO Get(int id);
        Product Insert(ProductDTO entity);
        Product Update(ProductDTO entity);



    }
}
