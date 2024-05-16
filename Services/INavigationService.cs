using YourWatch.Admin.Mobile.Models;

namespace YourWatch.Admin.Mobile.Services;

public interface INavigationService
{
    Task GoToEventDetail(Guid id);
    Task GoToAddEvent();
    Task GoToEditEvent(EventModel detailModel);
    Task GoToOverview();
    Task GoBack();
}