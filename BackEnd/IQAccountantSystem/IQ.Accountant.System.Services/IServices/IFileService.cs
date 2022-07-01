using IQ.Accountant.System.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Accountant.System.Services.IServices
{
    public interface IFileService
    {
        Task<SuccessMessage> UploadFileAsync(IFormFile fileToUpload);
        byte[] GenerateBarcode(string code);

    }
}
