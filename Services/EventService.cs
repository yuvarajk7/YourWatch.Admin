using YourWatch.Admin.Mobile.Models;
using YourWatch.Admin.Mobile.Repositories;

namespace YourWatch.Admin.Mobile.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    public Task<List<EventModel>> GetEvents()
        => eventRepository.GetEvents();

    public Task<EventModel?> GetEvent(Guid id)
        => eventRepository.GetEvent(id);

    public Task<bool> UpdateStatus(Guid id, EventStatusModel status)
        => eventRepository.UpdateStatus(id, status);
    
    public Task<bool> CreateEvent(EventModel model)
        => eventRepository.CreateEvent(model);

    public Task<bool> EditEvent(EventModel model)
        => eventRepository.EditEvent(model);

    public Task<bool> DeleteEvent(Guid id)
        => eventRepository.DeleteEvent(id);
}