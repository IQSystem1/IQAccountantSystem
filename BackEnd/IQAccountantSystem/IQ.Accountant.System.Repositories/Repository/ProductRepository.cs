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
    public class ProductRepository : IProductRepository
    {
        
        private readonly IQAccountantSystemContext _context;
        private IRepository<Product> _repository;
        private IImageVideoRepository _imageVideoRepository;
        public ProductRepository(IQAccountantSystemContext context,IRepository<Product> repository, IImageVideoRepository imageVideoRepository)
        {
            _context = context;

            _repository = repository;
            _imageVideoRepository = imageVideoRepository;
        }
        public SuccessMessage Delete(int id)
        {
            var sm = new SuccessMessage();
            try
            {
                sm = _imageVideoRepository.DeleteByProductId(id);
                if (sm.isSuccess)
                {
                    if (sm.isSuccess)
                        sm = _repository.Delete(id);
                }
            }
            catch (Exception ex)
            {
                sm.isSuccess = false;
                sm.message = ex.Message;
            }
            return sm;
        }
        public IEnumerable<Product> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<Product> Get(PaginationInfo paginationInfo)
        {
            var sp1 = new SqlParameter("@PageNo", paginationInfo.PageNo);
            var sp2 = new SqlParameter("@PageSize", paginationInfo.PageSize);
            var products = _context.products.FromSqlRaw("Exec GET_PRODUCT @PageNo , @PageSize", sp1, sp2).ToList();
            return products;
        }

        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        public Product Insert(Product entity)
        {
            return _repository.Insert(entity);
        }



        public Product Update(Product entity)
        {
            return _repository.Update(entity);
        }
        public IEnumerable<Product> Search(ProductDTO productDto = null)
        {
            //must be procedure
            var products = new List<Product>();

            if (productDto == null)
                products = _context.products.ToList();


            else
            {
                if (productDto.productCode == null)
                    productDto.productCode = "";
                if (productDto.productName == null)
                    productDto.productName = "";
                if (productDto.productUnit == null)
                    productDto.productUnit = "";


                var sp1 = new SqlParameter("@productCode", productDto.productCode);
                var sp2 = new SqlParameter("@productName", productDto.productName);
                var sp3 = new SqlParameter("@productUnit", productDto.productUnit);
                products = _context.products.FromSqlRaw("Exec SEARCH_PRODUCT @productCode , @productName , @productUnit", sp1, sp2, sp3).ToList();
            }
            return products;


        }
     

        public Product GetProductByCode(string code)
        {
            var product = _context.products.Where(c => c.ProductCode == code).FirstOrDefault();
            return product;
        }

        public Product GetProductByIqCode(string code)
        {
            var product = _context.products.Where(c => c.ProductIqCode == code).FirstOrDefault();
            return product;
        }



    }
}
