namespace _9.MyService.Services
{
    public class HomeBuilderService
    {
        private IHomeBuilder _builderService;

        public HomeBuilderService(IHomeBuilder builderService)
        {
            _builderService = builderService;
        }
        public string GetInfo()
        {
            return _builderService.GetHomeInfo();
        }
    }
}
