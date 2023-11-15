namespace CreationalPatterns.Factory;

public interface IItem
{
    int Count { get; }
    void Use();
    void DisplayInfo();
}