using YourWatch.Admin.Mobile.Models;

namespace YourWatch.Admin.Mobile.Services;

public interface IEventService
{
    Task<List<EventModel>> GetEvents();
    Task<EventModel?> GetEvent(Guid id);
    Task<bool> UpdateStatus(Guid id, EventStatusModel status);
}