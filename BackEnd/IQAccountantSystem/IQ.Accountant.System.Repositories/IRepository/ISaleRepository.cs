using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Repositories.IRepository
{
    public interface ISaleRepository 
    {
        IEnumerable<Sale> Get(PaginationInfo paginationInfo);
        Sale Insert(Sale entity);
        IEnumerable<Sale> Get();

    }
}
