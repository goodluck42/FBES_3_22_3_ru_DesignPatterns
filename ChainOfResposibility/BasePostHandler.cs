namespace ChainOfResposibility;

public abstract class BasePostHandler : IPostHandler
{
    public abstract void Handle(Post post);

    public IPostHandler? Next { get; set; }
}