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
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleService _saleService;
        public SaleController(ISaleRepository saleRepository, ISaleService saleService)
        {
            _saleRepository = saleRepository;
            _saleService = saleService;
        }



        [HttpPost]
        public Sale Post(SaleProductDTO saleProduct)
        {
            var sale = _saleService.Insert(saleProduct);
            return sale;
        }

        [HttpPost("Get")]
        public IEnumerable<SaleDTO> Get([FromBody] PaginationInfo paginationInfo)
        {

            return _saleService.GetSales(paginationInfo);
        }

        [HttpGet("Count")]
        public TableCount GetCount()
        {
            return _saleService.GetCount();
        }
        [HttpGet("SearchByCode/{code}")]
        public IEnumerable<SaleDTO> SearchByCode(string code)
        {

            return _saleService.SearchByCode(code);
        }


    }
}
