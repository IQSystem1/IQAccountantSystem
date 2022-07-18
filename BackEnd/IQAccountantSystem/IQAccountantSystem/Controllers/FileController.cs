using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using ZXing;

namespace IQAccountantSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{barcode}")]
        public IActionResult GenerateBarcode(string barcode)
        {
            return File(_fileService.GenerateBarcode(barcode), "image/jpeg");
        }
        [HttpPost]
        public Task<SuccessMessage> UploadFileAsync([FromForm] FileDTO fileToUpload)
        {
            return _fileService.UploadFileAsync(fileToUpload.File);
        }

        [HttpGet("Qrcode/{qrcode}")]
        public IActionResult GenerateQrCode(string qrcode)
        {
            return File(_fileService.GenerateQrcode(qrcode), "image/jpeg");
        }
    

    }
}
