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

## Version 7
- Created API project
- Created Models Category, Event and EventStatus
- Created Event Repositories
- Created Event Services
- Registered Repositories, Services, ViewModels and Views in MauiProgram.cs
- Edit constructors in EventDetailViewModel and EventListOverviewViewModel
- Edit EventDetailPage and EventOverviewPage constructor and inject view model
- Removed code behind settings view model setting and add the ShellContent in AppShell to redirect to EventOverviewPage page.
- Added Platforms/Android/Resources/xml/network_security.xml
- Set network_security.xml property to "AndroidResource"
- Modify the AndroidManifest.xml and add the attribute android:networkSecurityConfig="@xml/network_security_config"
- Changed API based url to "10.0.2.2:<API_Port>"

```
<?xml version="1.0" encoding="utf-8"?>
<network-security-config>
    <domain-config cleartextTrafficPermitted="true">
        <domain includeSubdomains="true">10.0.2.2</domain>
    </domain-config>
</network-security-config>
```

## Version 8
- Added Navigation Service and implement Shell.GotoAsync(state, params)
- AppShell.xaml implement ShellContent and navigate to EventOverviewPage
- Register the INotification service in MauiProgram.cs
- Created IViewModelBase and inherited to other view model classes
- Added ActicityIndicator UI component on the view page
- Created ContentPageBase class and inherited to View Class as well as XAML page
- Change the <ContentPage> to <views:ContentPageBase>
- Update the view model inherited from ViewModelBase to enable and disable activity indicator on load of the page
- Inherit IQueryAttributable to capture parameter while navigating the view 
- Implement ApplyQueryAttributes to capture and validate parameters
- Communicate between view models using WeakReferenceManager implemented in IRecipient<> belongs to community MVVM

## Version 9
- Added POCO messages EventAddedOrChangedMessage and EventDeletedMessage helps to add or delete an event
- Added repositories CategoryRepository, Added method Insert, update and delete events in EventRepository
- Added resources MaterialIcons font and globalticket_logo image
- Added CategoryService, DialogService
- Added methods in NavigationService and EventService
- Created ViewModelBase support loading activity indicator
- Created CategoryViewModel, EventAddEditViewModel
- Created EventAddEditPage and LogoView views
- Register Repositories, services, views in MauiProgram.cs
- Added logo banner (LogoView) component in AppShell XAML <Shell.TitleView>
```
<Shell.TitleView>
    <views:LogoView/>
</Shell.TitleView>
```
- Register Event Add and update route in AppShell.cs 
```
Routing.RegisterRoute("event/add", typeof(EventAddEditPage));
Routing.RegisterRoute("event/edit", typeof(EventAddEditPage));
```
- Added ActivityIndicator in EventOverviewPage and EventDetailPage
```
<ActivityIndicator IsRunning="{Binding IsLoading}" />
```
- Added DeleteEvent button and implemented command DeleteEventCommand
- Added CancelEvent button and implemented command CancelEventCommand
- Implemented Add and Update event in EventAddEditViewModel
- Implemented validation rules using ObservableValidator which has many built in features 
  - data annotations attributes
  - INotifyDataErrorInfo
  - ValidateProperty
  - ValidateAllProperties
  - ClearAllErrors
  - GetErrors
- Display Alert
```
Shell.Current.DisplayAlert(title, message, acceptText, cancelText)
```
## Version 10
- Choose xUnit project
- Add a new project YourWatch.Admin.Mobile.Tests
- Install package NSubstitute
- Add project reference YourWatch.Admin.Mobile
- Edit YourWatch.Admin.Mobile.csproj and add "net8.0" in TargetFrameworks
- Update OutputType
```
<OutputType Condition="'$(TargetFramework)' != 'net8.0'">Exe</OutputType>
```
- 