namespace CreationalPatterns.Builder;

public class Motherboard
{
    public string Socket { get; set; } = null!; // 1155
    public Gpu Gpu { get; set; } = null!;
    public Cpu Cpu { get; set; } = null!;
    public Ram Ram { get; set; } = null!;
}