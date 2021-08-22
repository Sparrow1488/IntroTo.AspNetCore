using Microsoft.AspNetCore.Mvc;
using System;

namespace _2.DbWork.Controllers
{
    public class GalleryController : Controller
    {
        private readonly string LOCAL_FILES_ROOT = Environment.CurrentDirectory + @"/wwwroot/Sources/Files/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("load-file")]
        public IActionResult DownloadRandom()
        {
            string responseType = "application/octet-stream";
            string fileName = "random.jpg";
            return File("~img1.jpg", responseType, fileName);
        }
    }
}
