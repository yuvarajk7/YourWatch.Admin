﻿using YourWatch.Admin.Mobile.Views;

namespace YourWatch.Admin.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("event", typeof(EventDetailPage));
        Routing.RegisterRoute("event/add", typeof(EventAddEditPage));
        Routing.RegisterRoute("event/edit", typeof(EventAddEditPage));
    }
}