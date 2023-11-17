namespace CreationalPatterns.AbstractFactory.Models;

public class RazerHeadset : Headset
{
    public RazerHeadset()
    {
        NoiseCanceling = true;
        IsWireless = true;
        HasMicrophone = false;
        Db = 12;
    }
}