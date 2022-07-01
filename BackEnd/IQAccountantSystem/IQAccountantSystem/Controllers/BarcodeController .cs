//using BarcodeLib;
//using IQ.Accountant.System.Entities.DTO;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Drawing;
//using System.IO;
//using Vintasoft.Barcode.AspNetCore.ApiControllers;

//namespace IQAccountantSystem.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class BarcodeController : Controller
//    {
//        public BarcodeController() { }
//        [HttpGet]
//        public IActionResult GenerateBarcode()
//        {
//            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
//            Image image = barcode.Encode(TYPE.CODE39,"23456", Color.Black, Color.White, 250, 100);
//            var data = ConverImageToBytes(image);
//            return File(data, "image/jpeg");
//        }

//        private byte[] ConverImageToBytes(Image image)
//        {
//            using(MemoryStream ms = new MemoryStream())
//            {
//                image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
//                return ms.ToArray();
//            }
//        }
//    }
//}
