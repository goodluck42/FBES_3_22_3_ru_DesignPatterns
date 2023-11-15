namespace CreationalPatterns.Factory;

public class Laptop : IItem
{
    private int _count;

    public Laptop()
    {
        _count = 3;
    }

    public int Count => _count;

    public void Use()
    {
        if (_count != 0)
        {
            Console.WriteLine("Using Laptop");

            _count--;
        }
    }

    public string Model { get; set; } = null!;
    
    public void DisplayInfo()
    {
        Console.WriteLine($"({nameof(Laptop)}) Count: {Count}\nModel: {Model}");
    }
}