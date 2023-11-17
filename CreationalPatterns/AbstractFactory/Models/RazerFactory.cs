namespace CreationalPatterns.AbstractFactory.Models;

public class RazerFactory : PcComponentFactory
{
    public override Mouse CreateMouse()
    {
        return new RazerMouse();
    }

    public override Headset CreateHeadset()
    {
        return new RazerHeadset();
    }
}