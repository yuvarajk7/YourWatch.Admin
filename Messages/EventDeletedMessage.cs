namespace YourWatch.Admin.Mobile.Messages;

public class EventDeletedMessage
{
    public Guid EventId { get; }

    public EventDeletedMessage(Guid id)
    {
        EventId = id;
    }
}