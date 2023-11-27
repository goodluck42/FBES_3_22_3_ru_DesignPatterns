namespace ChainOfResposibility;

public class Topic
{
    public Topic()
    {
        Tags = new List<string>();
    }
    public User? UserCreatedTopic { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; }  = null!;
    public ICollection<string> Tags { get; set; }
}