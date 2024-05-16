using YourWatch.Admin.Mobile.Models;

namespace YourWatch.Admin.Mobile.Repositories;

public interface IEventRepository
{
    Task<List<EventModel>> GetEvents();
    Task<EventModel?> GetEvent(Guid id);
    Task<bool> UpdateStatus(Guid id, EventStatusModel status);
    Task<bool> CreateEvent(EventModel model);
    Task<bool> EditEvent(EventModel model);
    Task<bool> DeleteEvent(Guid id);
    
}