using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourWatch.Admin.Mobile.ViewModels;

namespace YourWatch.Admin.Mobile.Views;

public partial class EventOverviewPage : ContentPage
{
    public EventOverviewPage()
    {
        InitializeComponent();
        BindingContext = new EventListOverviewModel();
    }
}