namespace ChainOfResposibility;

public interface IPostHandler
{
    void Handle(Post post);
    IPostHandler? Next { get; set;  }
}