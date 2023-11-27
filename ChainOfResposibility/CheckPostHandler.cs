namespace ChainOfResposibility;

public class CheckPostHandler : BasePostHandler
{
    private readonly TopicDb _db;

    public CheckPostHandler(TopicDb db)
    {
        _db = db;
    }

    public override void Handle(Post post)
    {
        Topic? topic = _db.GetTopic(post.Topic.Title);

        if (topic == null)
        {
            Console.WriteLine($"User: {post.User.Login}" +
                              $"\nTitle: {post.Topic.Title}" +
                              $"\nDescription: {post.Topic.Description}");
        }
        else
        {
            throw new Exception("Failed to handle Topic. The same topic already exists");
        }
    }
}