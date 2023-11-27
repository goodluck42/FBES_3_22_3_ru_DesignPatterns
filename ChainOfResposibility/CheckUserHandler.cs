namespace ChainOfResposibility;

public class CheckUserHandler : BasePostHandler
{
    private readonly UserDb _db;

    public CheckUserHandler(UserDb db)
    {
        _db = db;
    }

    public override void Handle(Post post)
    {
        if (post.User == null)
        {
            throw new Exception("Failed to handle User. User not found!");
        }
        
        User? u = _db.GetUser(post.User.Login);
        
        if (u != null && u.Password == post.User.Password)
        {
            Next?.Handle(post);
        }
        else
        {
            throw new Exception("Failed to handle User");
        }
    }
}