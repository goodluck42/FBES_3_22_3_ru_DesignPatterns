using System.Text.Json;

namespace Mediator;

class MessageDb : ChatComponent
{
    private const string CFileName = "messages.json";
    
    private List<Message> _messages;
    
    public MessageDb(IChatMediator mediator) : base(mediator)
    {
        _messages = new List<Message>();
    }

    public void AddMessage(Message message)
    {
        if (!File.Exists(CFileName))
        {
            var file = File.Create(CFileName);
            
            file.Dispose();
        }

        _messages.Add(message);
        
        var json = JsonSerializer.Serialize(_messages);
        
        File.WriteAllText(CFileName, json);
    }
}