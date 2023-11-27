namespace ChainOfResposibility;

public class User
{
    public User()
    {
        Rights = new List<string>();
    }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<string> Rights { get; set; }
}