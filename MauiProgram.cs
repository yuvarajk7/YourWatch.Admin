using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using YourWatch.Admin.Mobile.Repositories;
using YourWatch.Admin.Mobile.Services;
using YourWatch.Admin.Mobile.ViewModels;
using YourWatch.Admin.Mobile.Views;

namespace YourWatch.Admin.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIconsRegular");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterRepositories()
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews();

#if DEBUG
        builder.Logging.AddDebug();
#endif
    
        return builder.Build();
    }
    
    private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
    {
        var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5078"
            : "http://localhost:5078";
        
        builder.Services.AddHttpClient("GloboTicketAdminApiClient",
            client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

            });

        builder.Services.AddTransient<IEventRepository, EventRepository>();
        builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
        return builder;
    }
    
    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IEventService, EventService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();

        return builder;
    }
    
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<EventListOverviewViewModel>();
        builder.Services.AddTransient<EventDetailViewModel>();
        builder.Services.AddTransient<EventAddEditViewModel>();
        
        return builder;
    }
    
    private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<EventOverviewPage>();
        builder.Services.AddTransient<EventDetailPage>();
        builder.Services.AddTransient<EventAddEditPage>();
        return builder;
    }
}