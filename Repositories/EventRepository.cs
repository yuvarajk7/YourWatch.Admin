using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using YourWatch.Admin.Mobile.Models;

namespace YourWatch.Admin.Mobile.Repositories;

public class EventRepository(IHttpClientFactory httpClientFactory) : IEventRepository
{
    public async Task<EventModel?> GetEvent(Guid id)
    {
        using HttpClient client = httpClientFactory.CreateClient("GloboTicketAdminApiClient");

        try
        {
            EventModel? @event = await client.GetFromJsonAsync<EventModel>(
                $"events/{id}",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return @event;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<EventModel>> GetEvents()
    {
        using HttpClient client = httpClientFactory.CreateClient("GloboTicketAdminApiClient");

        try
        {
            List<EventModel>? events = await client.GetFromJsonAsync<List<EventModel>>(
                $"events",
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return events ?? new List<EventModel>();
        }
        catch (Exception)
        {
            return new List<EventModel>();
        }
    }

    public async Task<bool> UpdateStatus(Guid id, EventStatusModel status)
    {
        using HttpClient client = httpClientFactory.CreateClient("GloboTicketAdminApiClient");

        try
        {
            var content = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
            var response = await client.PatchAsync($"events/{id}/status", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }
    
    public async Task<bool> CreateEvent(EventModel model)
    {
        using HttpClient client = httpClientFactory.CreateClient("GloboTicketAdminApiClient");

        try
        {
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"events", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> EditEvent(EventModel model)
    {
        using HttpClient client = httpClientFactory.CreateClient("GloboTicketAdminApiClient");

        try
        {
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"events/{model.Id}", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> DeleteEvent(Guid id)
    {
        using HttpClient client = httpClientFactory.CreateClient("GloboTicketAdminApiClient");

        try
        {
            var response = await client.DeleteAsync($"events/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }
    
}