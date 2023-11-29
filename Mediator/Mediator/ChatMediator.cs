namespace Mediator;

class ChatMediator : IChatMediator
{
    private Chat? _chat;
    private MessageDb? _messageDb;
    private ChatLogger? _chatLogger;
    
    public void SetChat(Chat chat)
    {
        _chat = chat;
    }

    public void SetMessageDb(MessageDb messageDb)
    {
        _messageDb = messageDb;
    }
    
    public void SetChatLogger(ChatLogger chatLogger)
    {
        _chatLogger = chatLogger;
    }
    
    public void Notify(object sender, Message message)
    {
        if (sender is Chat)
        {
            _messageDb?.AddMessage(message);
            _chatLogger?.LogMessage(message);
        }
    }
}