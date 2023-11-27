namespace ChainOfResposibility;

public class UserDb
{
    private List<User> _users;

    public UserDb()
    {
        _users = new List<User>();
    }
    
    public User? GetUser(string login)
    {
        return _users.FirstOrDefault(u => u.Login == login);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}