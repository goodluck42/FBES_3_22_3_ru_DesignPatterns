namespace CreationalPatterns.Prototype;

public interface ICloneable<T>
    where T : class
{
    T Clone();
}