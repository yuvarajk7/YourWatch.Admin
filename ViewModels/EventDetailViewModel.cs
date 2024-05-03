using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace YourWatch.Admin.Mobile.ViewModels;

public class EventDetailViewModel : INotifyPropertyChanged
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
        set => SetField(ref _id, value);
        // if (value.Equals(_id)) return;
        // _id = value;
        // OnPropertyChanged();
    }

    public string Name
    {
        get => _name;
        set
        {
            if(value.Equals(_name)) return;
            _name = value;
            OnPropertyChanged();
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            if (value.Equals(_price)) return;
            _price = value;
            OnPropertyChanged();
        }
    }

    public string ImageUrl
    {
        get => _imageUrl;
        set
        {
            if (value == _imageUrl) return;
            _imageUrl = value;
            OnPropertyChanged();
        }
    }

    public EventStatusEnum EventStatus
    {
        get => _eventStatus;
        set
        {
            SetField(ref _eventStatus, value);
            ((Command)CancelEventCommand).ChangeCanExecute();
        }
    }

    public DateTime Date
    {
        get => _date;
        set
        {
            SetField(ref _date, value);
            ((Command)CancelEventCommand).ChangeCanExecute();
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            if (value == _description) return;
            _description = value;
            OnPropertyChanged();
        }
    }

    public List<string> Artists
    {
        get => _artists;
        set
        {
            if (Equals(value, _artists)) return;
            _artists = value;
            OnPropertyChanged();
        }
    }

    public CategoryViewModel Category
    {
        get => _category;
        set
        {
            if (Equals(value, _category)) return;
            _category = value;
            OnPropertyChanged();
        }
    }

    public bool ShowLargerImage
    {
        get => _showLargerImage;
        set
        {
            SetField(ref _showLargerImage, value);
            OnPropertyChanged(nameof(ShowThumbnailImage));
        }
    }

    public bool ShowThumbnailImage => !ShowLargerImage;

    public ICommand CancelEventCommand
    {
        get;
    }

    private void CancelEvent() => EventStatus = EventStatusEnum.Cancelled;

    private bool CanCancelEvent() => EventStatus != EventStatusEnum.Cancelled &&
                                     Date.AddHours(-4) > DateTime.Now;

    public EventDetailViewModel()
    {
        CancelEventCommand = new Command(CancelEvent, CanCancelEvent);
        
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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}