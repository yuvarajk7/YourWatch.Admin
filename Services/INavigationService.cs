namespace YourWatch.Admin.Mobile.Services;

public interface INavigationService
{
    Task GoToEventDetail(Guid id);
}