namespace CreationalPatterns.AbstractFactory.Models;

public abstract class PcComponentFactory
{
    public abstract Mouse CreateMouse();
    public abstract Headset CreateHeadset();
}