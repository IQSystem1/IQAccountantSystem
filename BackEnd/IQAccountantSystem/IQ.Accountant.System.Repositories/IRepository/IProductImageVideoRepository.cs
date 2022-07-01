using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Repositories.IRepository
{
    public interface IProductImageVideoRepository 
    {
        SuccessMessage DeleteByProductIdAndImageVideoId(int pid, int iid);
        IEnumerable<ProductImageVideo> Get();
        ProductImageVideo Get(int id);
        ProductImageVideo Insert(ProductImageVideo entity);
        ProductImageVideo Update(ProductImageVideo entity);
        SuccessMessage Delete(int id);
        List<ProductImageVideo> GetByProductAndImageVideoId(int pid, int ivd);
        int GetImageIdByProductId(int productId);
        int GetVideoIdByProductId(int productId);

    }
}
