﻿using CommunityToolkit.Maui;
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
        return builder;
    }
    
    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<IEventService, EventService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        return builder;
    }
    
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<EventListOverviewViewModel>();

        builder.Services.AddTransient<EventDetailViewModel>();
        return builder;
    }
    
    private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<EventOverviewPage>();

        builder.Services.AddTransient<EventDetailPage>();
        return builder;
    }
}