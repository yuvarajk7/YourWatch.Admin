# YourWatch

## Version 4
- Added Community MVVM Library CommunityToolkit.Mvvm
- Implemented ObservableObject
- Use Boilerplate codes

## Version 5
- Removed Set and Get Property
- Decorated field with [ObservableProperty]
- Removed IRelayCommand CancelEventCommand get propery
- Decorated Event with [RelayCommand]
- Added [NotifyCanExecuteChangedFor(nameof(CancelEventCommand))]
- Make viewmodel class to Partial class
- Installed CommunityToolKit.Maui
- Use ListToStringConverter
- Add UseMauiCommunityToolkit() in MauiProgram.cs
- Modified view EventDetailPage.xaml

## Version 6
- Created EventListItemViewModel
- Created EventListOverviewModel
- Create EventOverviewPage and set binding context to EventListOverviewModel
- Make List to ObservableCollection to update the latest change in the collection property automatically
- Select an item in the collection using SelectedItem in CollectionView
- SelectedItem property set to ObservableProperty
- Set MainPage to EventOverviewPage
