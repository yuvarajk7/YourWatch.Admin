using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using YourWatch.Admin.Mobile.Models;
using YourWatch.Admin.Mobile.Services;
using YourWatch.Admin.Mobile.ViewModels.Base;

namespace YourWatch.Admin.Mobile.ViewModels;

public partial class EventListOverviewViewModel(IEventService eventService, INavigationService navigationService)
    : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<EventListItemViewModel> _events = new();

    [ObservableProperty]
    private EventListItemViewModel? _selectedEvent;

    [RelayCommand]
    private async Task NavigateToSelectedDetail()
    {
        if (SelectedEvent is not null)
        {
            await navigationService.GoToEventDetail(SelectedEvent.Id);
            SelectedEvent = null;
        }
    }

    public override async Task LoadAsync()
    {
        if (Events.Count == 0)
        {
            await Loading(GetEvents);
        }
    }
    
    private async Task GetEvents()
    {
        //await Task.Delay(5000);
        List<EventModel> events = await eventService.GetEvents();
        List<EventListItemViewModel> listItems = new();
        foreach (var @event in events)
        {
            listItems.Add(MapEventModelToEventListItemViewModel(@event));
        }
        Events.Clear();
        Events = listItems.ToObservableCollection();
    }

    private EventListItemViewModel MapEventModelToEventListItemViewModel(EventModel @event)
    {
        var category = new CategoryViewModel    
        {
            Id = @event.Category.Id,
            Name = @event.Category.Name,
        };

        return new EventListItemViewModel(
            @event.Id,
            @event.Name,
            @event.Price,
            @event.Date,
            @event.Artists,
            (EventStatusEnum)@event.Status,
            @event.ImageUrl,
            category);
    }
    
}