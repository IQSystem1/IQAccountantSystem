using BarcodeLib;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Repositories.IRepository;
using IQ.Accountant.System.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace IQ.Accountant.System.Services.Services
{
    public class FileService : IFileService
    {
        private IConfiguration _configuration;
        private readonly string containerName;
        private readonly IImageVideoRepository _imageRepository;
        public FileService(IConfiguration configuration, IImageVideoRepository imageRepository)
        {
            _configuration = configuration;
            containerName = _configuration.GetValue<string>("containerName");
            _imageRepository = imageRepository;
        }
        public async Task<SuccessMessage> UploadFileAsync(IFormFile fileToUpload)
        {
            string fileFullPath = null;
            string connectionString = _configuration.GetValue<string>("StorageConnectionStrings");
            if (fileToUpload == null)
            {
                return new SuccessMessage()
                {
                    isSuccess = false,
                    message = "file is null"
                };
            }
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(this.containerName);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        }
                        );
                }
                string fileName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(fileToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                cloudBlockBlob.Properties.ContentType = fileToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(fileToUpload.OpenReadStream());

                fileFullPath = cloudBlockBlob.Uri.ToString();
                return new SuccessMessage()
                {
                    isSuccess = true,
                    message = fileFullPath
                };

            }
            catch (Exception ex)
            {
                return new SuccessMessage()
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
         
        }
        public byte[] GenerateBarcode(string code)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            Image image = barcode.Encode(TYPE.CODE39Extended, code, Color.Black, Color.White, 250, 100);
            return ConverImageToBytes(image);

        }

        public byte[] GenerateQrcode(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return ConverImageToBytes(qrCodeImage);

        }
        private byte[] ConverImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }



    }
}
