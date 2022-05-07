namespace Project.Api.FluentValidationLearn
{
    public class ApiResponse<TResult> : ApiResponse
    {
        public TResult Result { get; set; } = default!;
    }

    public class ApiResponse
    {
        public bool Ok { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Logs { get; set; } = new List<string>();

        public static ApiResponse Create<TResult>(TResult result)
        {
            return new ApiResponse<TResult>()
            {
                Result = result
            };
        }
    }
}
