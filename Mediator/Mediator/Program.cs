using Mediator;


var mediator = new ChatMediator();

var chat = new Chat(mediator);
var logger = new ChatLogger(mediator);
var messageDb = new MessageDb(mediator);

mediator.SetChat(chat);
mediator.SetChatLogger(logger);
mediator.SetMessageDb(messageDb);


{
    chat.Connect(new User()
    {
        Login = "mylogin",
        Name = "Semen"
    });

    chat.MessageSent += message =>
    {
        Console.WriteLine($"{message.Sender.Name} : {message.Text}");
    };

    var user = chat.GetUserByLogin("mylogin");
    
    chat.SendMessage(new Message(user, "Helloy Mediator!!!"));
}


// var chat = new Chat();
//
// chat.MessageSent += message =>
// {
//     Console.WriteLine($"{message.Sender.Name}: {message.Text}");
// };