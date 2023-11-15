namespace CreationalPatterns.Factory;

public class Phone : IItem
{
    private int _count;

    public Phone()
    {
        _count = 5;
    }

    public int Count => _count;

    public void Use()
    {
        if (_count != 0)
        {
            Console.WriteLine("Using Phone");

            _count--;
        }
    }

    public string Model { get; set; } = null!;
    
    public void DisplayInfo()
    {
        Console.WriteLine($"({nameof(Phone)}) Count: {Count}\nModel: {Model}");
    }
}