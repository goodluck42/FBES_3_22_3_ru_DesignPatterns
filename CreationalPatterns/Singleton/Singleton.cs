namespace CreationalPatterns.Singleton;

public sealed class UserRepository
{
    private IEnumerable<User> _localUser;

    private UserRepository()
    {
        _localUser = new List<User>();
    }

    public void AddUser(User user)
    {
    }

    public void RemoveUser(User user)
    {
        
    }

    private static UserRepository? _instance;

    public static UserRepository Instance => _instance ??= new UserRepository();
}