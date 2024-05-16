using YourWatch.Admin.Mobile.ViewModels;

namespace YourWatch.Admin.Mobile.Views;

public partial class EventAddEditPage : ContentPageBase
{
    public EventAddEditPage(EventAddEditViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}