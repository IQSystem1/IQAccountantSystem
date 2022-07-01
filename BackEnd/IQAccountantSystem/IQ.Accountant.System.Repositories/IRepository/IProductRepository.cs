using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Repositories.IRepository
{
    public interface IProductRepository 
    {
        IEnumerable<Product> Search(ProductDTO product = null);
        IEnumerable<Product> Get(PaginationInfo paginationInfo);
        Product GetProductByCode(string code);
        Product GetProductByIqCode(string code);
        IEnumerable<Product> Get();
        Product Get(int id);
        Product Insert(Product entity);
        Product Update(Product entity);
        SuccessMessage Delete(int id);

    }
}
