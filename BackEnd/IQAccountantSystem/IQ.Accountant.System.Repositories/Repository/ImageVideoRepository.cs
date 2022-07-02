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
    public class ImageVideoRepository : IImageVideoRepository
    {
        private IRepository<ImageVideo> _repository;
        private readonly IQAccountantSystemContext _context;
        private IProductImageVideoRepository _productImageVideoRepository;
        public ImageVideoRepository(IQAccountantSystemContext context, IRepository<ImageVideo> repository, IProductImageVideoRepository productImageRepository)
        {
            _context = context;
            _repository = repository;
            _productImageVideoRepository = productImageRepository;

        }

    
        public SuccessMessage DeleteByProductId(int productId)
        {
            var sm = new SuccessMessage();
            var imageIds = _context.productImageVideos.Where(p => p.ProductId == productId).Select(x => x.ImageVideoId).ToList();
            if (imageIds.Count == 0)
            {
                sm.isSuccess = true;
                return sm;
            }
            foreach (var id in imageIds)
            {
                sm = _repository.Delete(id);
                if (!sm.isSuccess)
                    return sm;
                else
                {
                    if (!_productImageVideoRepository.DeleteByProductIdAndImageVideoId(productId, id).isSuccess)
                        return sm;
                }
            }
            return sm;

        }

        public ImageVideo Insert(ImageVideo entity)
        {
            return _repository.Insert(entity);
        }
        public ImageVideo Update(ImageVideo entity)
        {
            return _repository.Update(entity);
        }
        public string GetByProductId(int productId)
        {
            var product = _context.products.Find(productId);
            if (product.ProductIqCode != null)
            {
                var imageId = _context.productImageVideos.Where(p => p.ProductId == productId).ToList().LastOrDefault().ImageVideoId;
                var image = _context.imageVideos.Find(imageId);
                return image.Url;
            }

            return string.Empty;
        }
        public ImageVideo GetVideoByProductId(int productId)
        {
            var videoId = _context.productImageVideos.Where(p => p.ProductId == productId && !p.IsImage).FirstOrDefault().ImageVideoId;
            var video = _context.imageVideos.Where(x => x.Id == videoId).FirstOrDefault();
            return video;
        }

        public ImageVideo GetImage(int productId)
        {
            int imageId = _productImageVideoRepository.GetImageIdByProductId(productId);
            if(imageId == -1)
                return null;
            var image = _context.imageVideos.Where(x=>x.Id==imageId).FirstOrDefault();
            return image;
        }

        public ImageVideo GetVideo(int productId)
        {
            int videoId = _productImageVideoRepository.GetVideoIdByProductId(productId);
            return _context.imageVideos.Where(x=>x.Id==videoId).FirstOrDefault();
        }

        public IEnumerable<ImageVideo> GetVideosByProductCode(string productCode)
        {
            var productIds = _context.products.Where(p => p.ProductCode == productCode).ToList().Select(x => x.Id);
            var videoIds = new List<int>();
            foreach(var productId in productIds)
            {
                var video = _context.productImageVideos.Where(v => v.ProductId == productId && !v.IsImage).FirstOrDefault();
                if(video!=null)
                    videoIds.Add(video.ImageVideoId);
            }
            var videos = new List<ImageVideo>();
            foreach(var videoId in videoIds)
            {
                videos.Add(_context.imageVideos.Find(videoId));
            }
            return videos;
        }
        public IEnumerable<ImageVideo> GetVideosByProductIqCode(string productCode)
        {
            var productIds = _context.products.Where(p => p.ProductIqCode == productCode).ToList().Select(x => x.Id);
            var videoIds = new List<int>();
            foreach (var productId in productIds)
            {
                var video = _context.productImageVideos.Where(v => v.ProductId == productId && !v.IsImage).FirstOrDefault();
                if (video != null)
                    videoIds.Add(video.ImageVideoId);
            }
            var videos = new List<ImageVideo>();
            foreach (var videoId in videoIds)
            {
                videos.Add(_context.imageVideos.Find(videoId));
            }
            return videos;
        }

    }
}
