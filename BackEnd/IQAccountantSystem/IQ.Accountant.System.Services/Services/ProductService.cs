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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageVideoRepository _imageVideoRepository;
        private IProductImageVideoRepository _productImageVideoRepository;
        private IFileService _fileService;
        public ProductService(IProductRepository productRepository, IImageVideoRepository imageRepository, 
            IProductImageVideoRepository productImageVideoRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _imageVideoRepository = imageRepository;
            _productImageVideoRepository = productImageVideoRepository;
            _fileService = fileService;
        }

        public ProductDTO Get(int id)
        {
            var product = _productRepository.Get(id);
            return ConvertProductToProductDTO(product);
        }

        public IEnumerable<ProductDTO> Get(PaginationInfo paginationInfo)
        {
            var products = _productRepository.Get(paginationInfo);
            List<ProductDTO> productsList = new List<ProductDTO>();

            foreach (var product in products)
            {
                productsList.Add(
                    ConvertProductToProductDTO(product)
                );
            }
            return productsList;
        }

        private ProductDTO ConvertProductToProductDTO(Product product)
        {
            if (product == null)
                return null;
            var image = _imageVideoRepository.GetImage(product.Id);
            var video = _imageVideoRepository.GetVideo(product.Id);
            var imageUrl = image == null ? "" : image.Url;
            var videoUrl = video == null ? "" : video.Url;
            return new ProductDTO()
            {
                productId = product.Id,
                productCode = product.ProductCode,
                productName = product.ProductName,
                productUnit = product.ProductUnit,
                productPrice = product.ProductPrice,
                productNote = product.ProductNote,
                productTax = product.ProductTax,
                productIqCode = product.ProductIqCode,
                imageUrl = imageUrl,
                videoUrl = videoUrl
            };
        }

        public IEnumerable<ProductDTO> Search(ProductDTO product = null)
        {
            var products = _productRepository.Search(product).ToList();

            var productsDto = new List<ProductDTO>();

            foreach (var p in products)
            {
                productsDto.Add(
                    ConvertProductToProductDTO(p)
                    );
            }

            return productsDto;
        }

        public Product Insert(Product entity)
        {
            
            var products = _productRepository.Get().Select(x => x.ProductIqCode);
            var code = GenerateRandomCode();

            while (products.Contains(code))
            {
                code = GenerateRandomCode();
            }
            entity.ProductIqCode = code;

            
            return _productRepository.Insert(entity);
        }

        public Product Insert(ProductDTO entity)
        {
            

            var product = this.Insert(ConverProductDTOToProduct(entity));

            if (product.ErrorMessage != null)
            {
                return product;
            }

            if (entity.imageUrl!=null)
            {
                var productImage = this.InsertImage(entity.imageUrl, product.Id);
                if (productImage.ErrorMessage!=null)
                {
                    return new Product()
                    {
                        ErrorMessage = productImage.ErrorMessage
                    };
                }
            }

            if (entity.videoUrl!=null)
            {
                var productVideo = this.InsertVideo(entity.videoUrl, product.Id);
                if (productVideo.ErrorMessage != null)
                {
                    return new Product()
                    {
                        ErrorMessage = productVideo.ErrorMessage
                    };
                }
            }

            return product;
            
        }

        private string GenerateRandomCode()
        {
            string code = "";
            int random_number = new Random().Next(1, 10);

            int n = 0;
            while (n < 7)
            {
                random_number = new Random().Next(1, 10);
                code += random_number.ToString();
                n++;
            }
            return code;
        }

        private Product ConverProductDTOToProduct(ProductDTO productDTO)
        {
            
            return new Product()
            {
                ProductCode = productDTO.productCode,
                Id = productDTO.productId,
                ProductIqCode = productDTO.productIqCode,
                ProductName = productDTO.productName,
                ProductNote = productDTO.productNote,
                ProductPrice = productDTO.productPrice,
                ProductUnit = productDTO.productUnit,
                ProductTax = productDTO.productTax,

            };
        }

        public ProductImageVideo InsertImage(string url, int productId)
        {

            var image = _imageVideoRepository.Insert(new ImageVideo()
            {
                Url = url,
            });
            if (image != null)
            {
                var productImage = _productImageVideoRepository.Insert(new ProductImageVideo()
                {
                    ImageVideoId = image.Id,
                    ProductId = productId,
                    IsImage = true,
                });
                return productImage;
            }
            else
            {
                return new ProductImageVideo()
                {
                    ErrorMessage = image.ErrorMessage
                };
            }
        }
        public ProductImageVideo InsertVideo(string url, int productId)
        {
            var video = _imageVideoRepository.Insert(new ImageVideo()
            {
                Url = url,
            });
            if (video != null)
            {
                var productVideo = _productImageVideoRepository.Insert(new ProductImageVideo()
                {
                    ImageVideoId = video.Id,
                    ProductId = productId,
                    IsImage = false,
                });
                return productVideo;
            }
            else
            {
                return new ProductImageVideo()
                {
                    ErrorMessage = video.ErrorMessage
                };
            }
        }







        public Product Update(Product entity)
        {
            return _productRepository.Update(entity);
        }

        public Product Update(ProductDTO entity)
        {
            Product product = ConverProductDTOToProduct(entity);
            try
            {
                if (!String.IsNullOrEmpty(entity.imageUrl))
                {
                    var image = _imageVideoRepository.GetImage(entity.productId);
                    if(image == null)
                    {
                        image = new ImageVideo()
                        {
                            Url = entity.imageUrl
                        };
                        image= _imageVideoRepository.Insert(image);
                        _productImageVideoRepository.Insert(new ProductImageVideo() { ImageVideoId = image.Id, ProductId = entity.productId , IsImage = true});
                    }
                    else
                    {
                        image.Url = entity.imageUrl;
                        _imageVideoRepository.Update(image);
                    }
                    


                }
                if (!String.IsNullOrEmpty(entity.videoUrl))
                {
                    var video = _imageVideoRepository.GetVideo(entity.productId);
                    if (video != null)
                    {
                        video.Url = entity.videoUrl;
                        _imageVideoRepository.Update(video);
                    }
                    else
                    {
                        video = new ImageVideo()
                        {
                            Url = entity.videoUrl
                        };
                        video = _imageVideoRepository.Insert(video);
                        _productImageVideoRepository.Insert(new ProductImageVideo() { ImageVideoId = video.Id, ProductId = entity.productId, IsImage=false });
                    }
                }
               
                product = _productRepository.Update(product);
                return product;
            }catch(Exception ex)
            {
                product = new Product();
                product.ErrorMessage = ex.Message;
                return product;
            }

        }




    }


}




    

