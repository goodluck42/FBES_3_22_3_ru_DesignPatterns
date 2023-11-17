namespace CreationalPatterns.AbstractFactory.Models;

public class LogitechFactory : PcComponentFactory
{
    public override Mouse CreateMouse()
    {
        return new LogitechMouse();
    }

    public override Headset CreateHeadset()
    {
        return new LogitechHeadset();
    }
}