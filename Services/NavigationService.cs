namespace YourWatch.Admin.Mobile.Services;

public class NavigationService : INavigationService
{
    public async Task GoToEventDetail(Guid id)
    {
        var parameters = new Dictionary<string, object> { {"EventId", id}};
        await Shell.Current.GoToAsync("event", parameters);
    }
}