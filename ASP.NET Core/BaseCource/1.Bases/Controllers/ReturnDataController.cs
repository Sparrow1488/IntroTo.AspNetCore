using Microsoft.AspNetCore.Mvc;

namespace _1.Bases.Controllers
{
    [Route("/return")]
    public class ReturnDataController : Controller
    {
        [Route("local")]
        public IActionResult ShowMessage()
        {
            return Ok("Local redirect success;)");
        }

        [HttpGet("google")]
        public IActionResult GetCreatedResults()
        {
            return Created("https://cock.and.balls/", new { Description = "Nice site" });
        }

        [HttpGet("status200")]
        public IActionResult GetSuccessStatusCode()
        {
            return Ok("status 200: OK");
        }

        [HttpGet("no-content")]
        public IActionResult GetEmptyContent()
        {
            return NoContent();
        }

        [HttpGet("unsupported")]
        public IActionResult UnsupportedMediaTypeResult()
        {
            return new UnsupportedMediaTypeResult();
        }

        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return Redirect("https://www.youtube.com/");
        }

        [HttpGet("local-redirect")]
        public IActionResult CompleteLocalRedirect()
        {
            return LocalRedirect("/return/local");
        }

        [HttpGet("action-redirect")]
        public IActionResult ActionRedirect()
        {
            return RedirectToAction("local-redirect", "return");
        }

        [HttpGet("get-file")]
        public IActionResult GetFile()
        {
            string filePath = @"C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\1.Bases\Sources\Images\img1.jpg";
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/jpg");
        }
    }
}
