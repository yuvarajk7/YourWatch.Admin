using YourWatch.Admin.Mobile.ViewModels;

namespace YourWatch.Admin.Mobile.Messages;

public class StatusChangedMessage(Guid id, EventStatusEnum status)
{
    public Guid EventId { get; } = id;
    public EventStatusEnum Status { get; } = status;
}