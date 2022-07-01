using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Repositories.IRepository;
using IQ.Accountant.System.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IQAccountantSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageVideoController : Controller
    {
        private readonly IImageVideoRepository _imageVideoRepository;
        public ImageVideoController(IImageVideoRepository imageRepository)
        {
            _imageVideoRepository = imageRepository;
        }

        

        [HttpGet("Image/{id}")]
        public ImageVideo GetImage(int id)
        {
            return _imageVideoRepository.GetImage(id);
        }
        [HttpGet("Video/{id}")]
        public ImageVideo GetVideo(int id)
        {
            return _imageVideoRepository.GetVideo(id);
        }

        [HttpPost]
        public ImageVideo Post(ImageVideo image)
        {


            return _imageVideoRepository.Insert(image);
        }

        [HttpPut]
        public ImageVideo Put(ImageVideo image)
        {
            return _imageVideoRepository.Update(image);
        }


        [HttpGet("GetVideoByProductId/{productId}")]
        public ImageVideo GetVideoByProductId(int productId)
        {
            return _imageVideoRepository.GetVideoByProductId(productId);
        }

        [HttpGet("GetVideosByProductCode/{productCode}")]
        public IEnumerable<ImageVideo> GetVideosByProductCode(string productCode)
        {
            return _imageVideoRepository.GetVideosByProductCode(productCode);
        }
    }
}
