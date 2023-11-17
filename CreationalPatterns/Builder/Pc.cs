namespace CreationalPatterns.Builder;

public class Pc
{
    public Motherboard Motherboard { get; set; } = null!;
    public Psu Psu { get; set; } = null!;
    public Ssd Ssd { get; set; } = null!;
}