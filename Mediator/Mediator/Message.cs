namespace Mediator;

class Message
{
    public Message(User user, string text)
    {
        Sender = user;
        Text = text;
    }

    public User Sender { get; }
    public string? Text { get; }
}