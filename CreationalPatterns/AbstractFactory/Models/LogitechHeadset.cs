namespace CreationalPatterns.AbstractFactory.Models;

public class LogitechHeadset : Headset
{
    public LogitechHeadset()
    {
        NoiseCanceling = true;
        IsWireless = false;
        HasMicrophone = true;
        Db = 10;
    }
}