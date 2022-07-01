using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IQAccountantSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
            return _fileService.UploadFileAsync(fileToUpload.file);
        }
    }
}
