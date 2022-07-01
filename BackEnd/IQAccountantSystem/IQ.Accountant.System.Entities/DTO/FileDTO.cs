using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Entities.DTO
{
    public class FileDTO
    {
        public IFormFile file { get; set; }
    }
}
