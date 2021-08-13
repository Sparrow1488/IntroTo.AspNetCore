using _1.Bases.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.Bases.Controllers
{
    [Route("/[controller]")]
    public class BlogController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("This is base page of blog controller");
        }

        [Route("article/{articleId?}")]
        public IActionResult ArticleConcrete(int articleId)
        {
            return Ok($"You call article by id = {articleId}");
        }

        [HttpGet]
        public IActionResult GetSomeId([FromQuery] int someId)
        {
            return Ok($"You received this id : {someId}");
        }

        [HttpPost]
        public IActionResult LoadFile([FromForm] string sender, [FromForm] IFormFile file)
        {
            return Ok($"Loaded success!\nFile name : {file.FileName}; Loader: {sender}");
        }
    }
}
