namespace ChainOfResposibility;

public class CheckUserRightsHandler : BasePostHandler
{
    private readonly UserDb _db;

    public CheckUserRightsHandler(UserDb db)
    {
        _db = db;
    }

    public override void Handle(Post post)
    {
        User? u = _db.GetUser(post.User!.Login);

        if (!u!.Rights.Contains("banned"))
        {
            Next?.Handle(post);
        }
        else
        {
            throw new Exception("Failed to handle User Rights");
        }
    }
}