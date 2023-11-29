namespace Mediator;

abstract class ChatComponent
{
    protected IChatMediator Mediator;

    protected ChatComponent(IChatMediator mediator)
    {
        Mediator = mediator;
    }
}