using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Repositories.IRepository
{
    public interface IImageVideoRepository 
    {
        
        ImageVideo Insert(ImageVideo entity);
        ImageVideo Update(ImageVideo entity);
        ImageVideo GetImage(int productId);
        ImageVideo GetVideo(int productId);
        string GetByProductId(int productId);
        ImageVideo GetVideoByProductId(int productId);
        SuccessMessage DeleteByProductId(int productId);
        IEnumerable<ImageVideo> GetVideosByProductCode(string productCode);
        IEnumerable<ImageVideo> GetVideosByProductIqCode(string productCode);



    }
}
