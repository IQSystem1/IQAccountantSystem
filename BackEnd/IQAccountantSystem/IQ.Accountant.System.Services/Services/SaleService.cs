using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Repositories.IRepository;
using IQ.Accountant.System.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQ.Accountant.System.Services.Services
{
    public class SaleService : ISaleService
    {
        private ISaleRepository _saleRepository;
        public IProductRepository _productRepository;
        private IImageVideoRepository _imageRepository;
        public SaleService(ISaleRepository saleRepository, IProductRepository product, IImageVideoRepository imageRepository )
        {
            _saleRepository = saleRepository;
            _productRepository = product;
            _imageRepository = imageRepository;
        }

        public Sale Insert(SaleProductDTO saleProduct)
        {

            var product = _productRepository.GetProductByCode(saleProduct.ProductCode);
            var sale = new Sale()
            {
                ProductId = product.Id,
                Quantity = saleProduct.Quantity
            };
            return _saleRepository.Insert(sale);

        }

        public IEnumerable<Sale> Get()
        {
            return _saleRepository.Get();
        }

        public IEnumerable<SaleDTO> GetSales(PaginationInfo paginationInfo = null)
        {
            var salesDto = new List<SaleDTO>();
            var sales = _saleRepository.Get(paginationInfo);
            foreach (var sale in sales)
            {
                var product = _productRepository.Get(sale.ProductId);
                var tax = product.ProductTax != null ? product.ProductTax : 1;
                salesDto.Add(new SaleDTO()
                {
                    SaleId = sale.Id,
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    ProductQuantity = sale.Quantity,
                    ProductPrice = product.ProductPrice,
                    ProductUnit = product.ProductUnit,
                    ProductCode = product.ProductCode,
                    ProductTax = (float)tax,
                    ImageUrl = _imageRepository.GetByProductId(product.Id),
                    //VideoUrl = _vedioRepository.GetByProducrId(product.Id),
                    saleTime = sale.AddedDate.ToString()
                });
            }
            return salesDto;

        }

        public IEnumerable<SaleDTO> SearchByCode(string code)
        {

            var productId = _productRepository.GetProductByCode(code);
            if (productId == null)
            {
                return null;
            }
            var sales = this.Get().Where(x => x.ProductId == productId.Id).ToList();
            var salesDto = new List<SaleDTO>();
            foreach (var sale in sales)
            {
                var product = _productRepository.Get(sale.ProductId);
                var tax = product.ProductTax != null ? product.ProductTax : 1;
                salesDto.Add(new SaleDTO()
                {
                    SaleId = sale.Id,
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    ProductQuantity = sale.Quantity,
                    ProductPrice = product.ProductPrice,
                    ProductUnit = product.ProductUnit,
                    ProductCode = product.ProductCode,
                    ProductTax = (float)tax,
                    ImageUrl = _imageRepository.GetByProductId(product.Id),
                    //VideoUrl = _vedioRepository.GetByProducrId(product.Id),
                    saleTime = sale.AddedDate.ToString()
                });
            }
            return salesDto;
        }

        public TableCount GetCount()
        {
            return new TableCount()
            {
                Count = _saleRepository.Get().Count()
            };
        }


    }
}
