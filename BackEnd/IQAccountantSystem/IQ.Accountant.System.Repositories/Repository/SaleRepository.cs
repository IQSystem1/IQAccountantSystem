using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Model;
using IQ.Accountant.System.Repositories.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQ.Accountant.System.Repositories.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IQAccountantSystemContext _context;
        private IRepository<Sale> _repository;
        public SaleRepository(IQAccountantSystemContext context, IRepository<Sale> repository)
        {
            _context = context;
            _repository = repository;
        }

        public SuccessMessage Delete(int id)
        {
            return _repository.Delete(id);
        }
        public Sale Insert(Sale entity)
        {
            return _repository.Insert(entity);
        }

        public IEnumerable<Sale> Get()
        {
            return _repository.Get() ;
        }

        public Sale Get(int id)
        {
            return _repository.Get(id);
        }
        public IEnumerable<Sale> Get(PaginationInfo paginationInfo)
        {
            var sp1 = new SqlParameter("@PageNo", paginationInfo.PageNo);
            var sp2 = new SqlParameter("@PageSize", paginationInfo.PageSize);
            var sales = _context.sales.FromSqlRaw("Exec GET_SALE @PageNo , @PageSize", sp1, sp2).ToList();
            return sales;
        }

        public Sale Update(Sale entity)
        {
            return _repository.Update(entity);
        }

      
    }
}
