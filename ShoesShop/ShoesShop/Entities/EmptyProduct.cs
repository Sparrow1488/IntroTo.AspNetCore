namespace ShoesShop.Entities
{
    public class EmptyProduct : Product
    {
        public EmptyProduct()
        {
            Key = -1;
            Name = "Undefined";
            Description = "Not found";
        }
    }
}
