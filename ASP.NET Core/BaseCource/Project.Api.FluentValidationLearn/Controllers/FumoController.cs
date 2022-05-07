using Microsoft.AspNetCore.Mvc;
using Project.Api.FluentValidationLearn.ViewModels;

namespace Project.Api.FluentValidationLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FumoController : ControllerBase
    {
        private static CreateFumoViewModel _lastCreated = null!;

        [HttpGet("Get")]
        public ActionResult<ApiResponse<CreateFumoViewModel>> GetFumo()
        {
            var apiResponse = ApiResponse.Create(result: _lastCreated);
            if (_lastCreated is null)
                apiResponse.Logs.Add("Ни одна фумо еще не создана");
            return Ok(apiResponse);
        }

        [HttpPost("Create")]
        public ActionResult<ApiResponse<bool>> CreateFumo(CreateFumoViewModel vm)
        {
            var apiResponse = ApiResponse.Create(result: true);
            _lastCreated = vm;
            apiResponse.Logs.Add("Модель сохранена");
            return Ok(apiResponse);
        }
    }
}
