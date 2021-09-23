namespace ShoesShop.Entities
{
    public abstract class Product
    {
        public int Key { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string[] Images { get; set; } = new string[0];
        public double Price { get; set; }
    }
}
