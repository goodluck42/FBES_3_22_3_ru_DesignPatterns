namespace CreationalPatterns.Factory;

public class PhoneFactory : IItemFactory
{
    public IItem Create()
    {
        var phone = new Phone()
        {
            Model = string.Empty
        };

        return phone;
    }
}