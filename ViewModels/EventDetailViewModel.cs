using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace YourWatch.Admin.Mobile.ViewModels;

public class EventDetailViewModel : ObservableObject
{
    private Guid _id;
    private string _name = default!;
    private double _price;
    private string _imageUrl;
    private EventStatusEnum _eventStatus;
    private DateTime _date = DateTime.Now;
    private string _description;
    private List<string> _artists = new();
    private CategoryViewModel _category = new();
    private bool _showLargerImage;

    public Guid Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public double Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public string ImageUrl
    {
        get => _imageUrl;
        set => SetProperty(ref _imageUrl, value);
    }

    public EventStatusEnum EventStatus
    {
        get => _eventStatus;
        set
        {
            if (SetProperty(ref _eventStatus, value))
            {
                CancelEventCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public DateTime Date
    {
        get => _date;
        set
        {
            SetProperty(ref _date, value);
            CancelEventCommand.NotifyCanExecuteChanged();
        }
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public List<string> Artists
    {
        get => _artists;
        set => SetProperty(ref _artists, value);
    }

    public CategoryViewModel Category
    {
        get => _category;
        set => SetProperty(ref _category, value);
    }

    public bool ShowLargerImage
    {
        get => _showLargerImage;
        set
        {
            if ( SetProperty(ref _showLargerImage, value))
            {
                OnPropertyChanged(nameof(ShowThumbnailImage));
            }
        }
    }

    public bool ShowThumbnailImage => !ShowLargerImage;

    public IRelayCommand CancelEventCommand
    {
        get;
    }

    private void CancelEvent() => EventStatus = EventStatusEnum.Cancelled;

    private bool CanCancelEvent() => EventStatus != EventStatusEnum.Cancelled &&
                                     Date.AddHours(-4) > DateTime.Now;

    public EventDetailViewModel()
    {
        CancelEventCommand = new RelayCommand(CancelEvent, CanCancelEvent);
        
        Id = Guid.Parse("EE272F8B-6096-4CB6-8625-BB4BB2D89E8B");
        Name = "John Egberts Live";
        Price = 65;
        ImageUrl = "https://lindseybroospluralsight.blob.core.windows.net/globoticket/images/banjo.jpg";
        EventStatus = EventStatusEnum.OnSale;
        Date = DateTime.Now.AddMonths(6);
        Description = "Join John for his farewell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.";
        Artists = new List<string> { "John Egbert", "Jane Egbert" };
        Category = new CategoryViewModel
        {
            Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
            Name = "Concert"
        };
    }
}