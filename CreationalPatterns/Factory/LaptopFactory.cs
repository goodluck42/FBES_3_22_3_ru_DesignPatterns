namespace CreationalPatterns.Factory;

public class LaptopFactory : IItemFactory
{
    public IItem Create()
    {
        var laptop = new Laptop()
        {
            Model = string.Empty
        };

        return laptop;
    }
}