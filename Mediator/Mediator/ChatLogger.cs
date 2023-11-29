namespace Mediator;

class ChatLogger : ChatComponent
{
    private const string CFileName = "logs.txt";
    
    public ChatLogger(IChatMediator mediator) : base(mediator) { }

    public void LogMessage(Message message)
    {
        File.AppendAllText(CFileName, $"[{DateTime.Now}] ({message.Sender.Name}): {message.Text}\n");
    }
}