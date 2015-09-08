using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using YeeYanUWP;
using YeeYanUWP.ViewModels;
using System;
using System.Net;
using System.Windows;


namespace MVVMSidekick.Startups
{
    internal static partial class StartupFunctions
    {
        static Action DetailPageConfig =
           CreateAndAddToAllConfig(ConfigDetailPage);

        public static void ConfigDetailPage()
        {
            ViewModelLocator<DetailPage_Model>
                .Instance
                .Register(context =>
                    new DetailPage_Model())
                .GetViewMapper()
                .MapToDefault<DetailPage>();

        }
    }
}
