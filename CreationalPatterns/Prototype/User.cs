namespace CreationalPatterns.Prototype;

public class User : ICloneable<User>
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    
    public User Clone()
    {
        return new User()
        {
            Login = Login,
            Password = Password
        };
    }
}