using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Model;
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
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        public ProductController(IProductRepository productRepository,
            IProductService productService)
        {
            _productRepository = productRepository;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return _productService.Search();
        }

        [HttpGet("Get/{code}")]
        public IEnumerable<ProductDTO> Get(string code)
        {
            var product = _productService.Search(new ProductDTO { productCode = code });
            return product;
        }

        


        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            return _productService.Get(id);
        }

        [HttpPost]
        public Product Post(ProductDTO product)
        {
            return _productService.Insert(product);
        }

       


        [HttpPut]
        public Product Put(ProductDTO product)
        {
            return _productService.Update(product);
        }

        [HttpDelete("{id}")]
        public SuccessMessage Delete(int id)
        {
            return _productRepository.Delete(id);
        }


        [HttpPost("Get")]
        public IEnumerable<ProductDTO> Get(PaginationInfo paginationInfo)
        {
            var products= _productService.Get(paginationInfo);
            return products;
        }

        [HttpPost("Search")]
        public IEnumerable<ProductDTO> Search(ProductDTO product)
        {
            var products = _productService.Search(product);
            return products;
        }
    }
}
