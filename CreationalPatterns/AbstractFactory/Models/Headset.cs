namespace CreationalPatterns.AbstractFactory.Models;

public abstract class Headset
{
    public bool NoiseCanceling { get; set; }
    public bool IsWireless { get; set; }
    public bool HasMicrophone { get; set; }
    public double Db { get; set; }
}