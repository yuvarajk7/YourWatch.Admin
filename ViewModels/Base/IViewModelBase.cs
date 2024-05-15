using CommunityToolkit.Mvvm.Input;

namespace YourWatch.Admin.Mobile.ViewModels.Base;

public interface IViewModelBase
{
    IAsyncRelayCommand InitializeAsyncCommand { get; }
}
