using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Entities.DTO
{
    public class SuccessMessage
    {
        public string message { get; set; }
        public bool isSuccess { get; set; }
        public DateTime dateTime { get; set; }
    }
}
