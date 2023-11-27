// Title
// Description


using ChainOfResposibility;

var userDb = new UserDb();
var topicDb = new TopicDb();

userDb.AddUser(new User()
{
    Login = "my_login",
    Password = "my_password",
    Rights = { "default" }
});

topicDb.AddTopic(new Topic()
{
    UserCreatedTopic = userDb.GetUser("my_login"),
    Title = "Variables in C++",
    Description = "I don't know how to create a variable in C++. Help!!!",
    Tags = { "C++" }
});
{
    IPostHandler userHandler = new CheckUserHandler(userDb);
    IPostHandler userRightsHandler = new CheckUserRightsHandler(userDb);
    IPostHandler checkPostHandler = new CheckPostHandler(topicDb);

    userHandler.Next = userRightsHandler;
    userRightsHandler.Next = checkPostHandler;

    // Calling chain of handlers
    var user = userDb.GetUser("my_login");
    var post = new Post()
    {
        User = user,
        Topic = new Topic()
        {
            UserCreatedTopic = user,
            Title = "Loops C++",
            Description = "How to create loop?",
            Tags = { "C++" }
        }
    };

    try
    {
        userHandler.Handle(post);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    
}