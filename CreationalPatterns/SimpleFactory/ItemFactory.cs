using CreationalPatterns.Factory;

namespace CreationalPatterns.SimpleFactory;

public class ItemFactory
{
    IItem? Create(int type)
    {
        if (type == 1)
        {
            return new Laptop();
        }

        if (type == 2)
        {
            return new Phone();
        }

        return null;
    }
}