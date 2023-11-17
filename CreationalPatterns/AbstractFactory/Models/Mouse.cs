namespace CreationalPatterns.AbstractFactory.Models;

public abstract class Mouse
{
    public int Dpi { get; set; }
    public int Buttons { get; set; }
    public int Frequency { get; set; }
}


public class LogitechMouse : Mouse
{
    public LogitechMouse()
    {
        Dpi = 10000;
        Buttons = 4;
        Frequency = 1000;
    }
}

public class RazerMouse : Mouse
{
    public RazerMouse()
    {
        Dpi = 20000;
        Buttons = 7;
        Frequency = 1000;
    }
}