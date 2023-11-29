namespace Mediator;

class Chat : ChatComponent
{
    private List<User> _users;

    public Chat(IChatMediator mediator) : base(mediator)
    {
        _users = new List<User>();
    }

    public void Connect(User user)
    {
        _users.Add(user);
    }

    public User GetUserByLogin(string login)
    {
        return _users.First(u => u.Login == login);
    }
    
    public event Action<Message>? MessageSent;
    
    public void SendMessage(Message message)
    {
        MessageSent?.Invoke(message);
        
        Mediator.Notify(this, message);
    }
}