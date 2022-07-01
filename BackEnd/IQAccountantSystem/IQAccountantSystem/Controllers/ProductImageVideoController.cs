using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IQAccountantSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductImageController : Controller
    {
        private readonly IProductImageVideoRepository _imageRepository;
        public ProductImageController(IProductImageVideoRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public IEnumerable<ProductImageVideo> Get()
        {
            return _imageRepository.Get();
        }

        [HttpGet("{id}")]
        public ProductImageVideo Get(int id)
        {
            return _imageRepository.Get(id);
        }

        [HttpPost]
        public ProductImageVideo Post(ProductImageVideo Image)
        {
            return _imageRepository.Insert(Image);
        }

        [HttpPut]
        public ProductImageVideo Put(ProductImageVideo Image)
        {
            return _imageRepository.Update(Image);
        }
    }
}
