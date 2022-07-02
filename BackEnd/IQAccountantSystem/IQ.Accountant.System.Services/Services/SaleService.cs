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

            var product = _productRepository.GetProductByIqCode(saleProduct.ProductIqCode);
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
                salesDto.Add(ConvertSaleToSaleDTO(sale));
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
                salesDto.Add(ConvertSaleToSaleDTO(sale));
            }
            return salesDto;
        }

        public IEnumerable<SaleDTO> SearchByIqCode(string code)
        {

            var productId = _productRepository.GetProductByIqCode(code);
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
                salesDto.Add(ConvertSaleToSaleDTO(sale));
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

        private SaleDTO ConvertSaleToSaleDTO(Sale sale)
        {
            var image = _imageRepository.GetImage(sale.ProductId);
            var video = _imageRepository.GetVideo(sale.ProductId);
            var imageUrl = image == null ? "" : image.Url;
            var videoUrl = video == null ? "" : video.Url;

            var product = _productRepository.Get(sale.ProductId);

            return new SaleDTO()
            {
                SaleId = sale.Id,
                ProductId = sale.ProductId,
                ProductName = product.ProductName,
                ProductQuantity = sale.Quantity,
                ProductPrice = product.ProductPrice,
                ProductUnit = product.ProductUnit,
                ProductCode = product.ProductCode,
                ProductNote = product.ProductNote,
                ProductTax = product.ProductTax,
                ImageUrl = imageUrl,
                VideoUrl = videoUrl,
                ProductIqCode = product.ProductIqCode,
                saleTime = sale.AddedDate.ToString()
            };
        }


    }
}
