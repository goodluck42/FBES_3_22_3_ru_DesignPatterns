using System.Threading.Channels;

public sealed class Singleton
{
    private Singleton()
    {
    }

    private static Singleton? _field;

    // public static Singleton Instance => _field ??= new Singleton();
    public static Singleton Instance
    {
        get
        {
            if (_field == null)
            {
                _field = new();
            }

            return _field;
        }
    }
}