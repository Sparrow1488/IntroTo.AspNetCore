using Microsoft.AspNetCore.Mvc;

namespace Project.Api.FluentValidationLearn.Extensions
{
    public static class MvcBuilderExtensions
    {
        /// <summary>
        /// Use it to create response with 400 code and custom response body
        /// </summary>
        public static IMvcBuilder UseCustomValidationResult(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = false; // true, если пропустить валидацию и передать объект сразу в Action контроллера
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var validationErrors = actionContext.ModelState.Values.SelectMany(x => x.Errors).ToList();
                    var apiResult = new ApiResponse();
                    apiResult.Errors = validationErrors.Select(x => x.ErrorMessage).ToList();
                    apiResult.Ok = false;
                    var badRequest = new BadRequestObjectResult(apiResult);
                    return badRequest;
                };
            });
            return builder;
        }
    }
}
