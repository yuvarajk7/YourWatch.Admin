using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace YourWatch.Admin.Mobile.ViewModels;

public class CategoryViewModel : ObservableObject
{
    private Guid _id;
    private string _name = default!;

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
}