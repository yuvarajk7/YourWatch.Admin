using YourWatch.Admin.Mobile.Views;

namespace YourWatch.Admin.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();         
    }
}