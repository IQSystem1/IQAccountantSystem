using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Model;
using IQ.Accountant.System.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQ.Accountant.System.Repositories.Repository
{
    public class ProductImageVideoRepository : IProductImageVideoRepository
    {
        private IRepository<ProductImageVideo> _repository;
        private readonly IQAccountantSystemContext _context;

        public ProductImageVideoRepository(IRepository<ProductImageVideo> repository, IQAccountantSystemContext context)
        {
            _repository = repository;
            _context = context;
        }

        public SuccessMessage Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<ProductImageVideo> Get()
        {
            return _repository.Get();
        }

        public ProductImageVideo Get(int id)
        {
            return _repository.Get(id);
        }

        public ProductImageVideo Insert(ProductImageVideo entity)
        {
            return _repository.Insert(entity);
        }

        public ProductImageVideo Update(ProductImageVideo entity)
        {
            return _repository.Update(entity);
        }



        public SuccessMessage DeleteByProductIdAndImageVideoId(int pid, int iid)
        {
            var sm = new SuccessMessage();
            sm.isSuccess = true;
            try
            {
                var all = this.GetByProductAndImageVideoId(pid, iid);
                foreach (var item in all)
                {
                    this.Delete(item.Id);
                }
                return sm;
            }
            catch (Exception ex)
            {
                sm.isSuccess = false;
                sm.message = ex.Message;
                return sm;
            }
        }

        public List<ProductImageVideo> GetByProductAndImageVideoId(int pid, int ivd)
        {
            return this.Get().Where(pv => pv.ProductId == pid && pv.ImageVideoId == ivd).ToList();
        }

        public int GetImageIdByProductId(int productId)
        {
            var id = this.Get().Where(p => p.ProductId == productId && p.IsImage).FirstOrDefault();
            return  id==null? -1:id.ImageVideoId;
        }
        public int GetVideoIdByProductId(int productId)
        {
            var id= this.Get().Where(p => p.ProductId == productId && !p.IsImage).FirstOrDefault();
            return id == null ? -1 : id.ImageVideoId;

        }


    }
}
