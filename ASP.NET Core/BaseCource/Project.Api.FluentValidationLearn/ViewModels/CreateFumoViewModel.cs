namespace Project.Api.FluentValidationLearn.ViewModels
{
    public class CreateFumoViewModel
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<string> Tags { get; set; } = new List<string>();
        public double Price { get; set; }
        public int Height { get; set; }
        public string Article { get; set; }
    }
}
