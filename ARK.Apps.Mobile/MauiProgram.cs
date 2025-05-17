// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Brokers.Arks;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Services.Foundations;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace ARK.Apps.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder mauiAppBuilder =
                MauiApp.CreateBuilder();

            mauiAppBuilder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

            mauiAppBuilder.Services.AddMauiBlazorWebView();
            mauiAppBuilder.Services.AddLogging();
            mauiAppBuilder.Services.AddHttpClient();

            mauiAppBuilder.Services.AddTransient<
                ILoggingBroker,
                LoggingBroker>();

            mauiAppBuilder.Services.AddTransient<
                IArkApiBroker,
                ArkApiBroker>();

            mauiAppBuilder.Services.AddTransient<
                IArkService,
                ArkService>();

            mauiAppBuilder.Services.AddTransient<
                IArkViewService,
                ArkViewService>();

#if DEBUG
            mauiAppBuilder.Services.AddBlazorWebViewDeveloperTools();
            mauiAppBuilder.Logging.AddDebug();
#endif

            return mauiAppBuilder.Build();
        }
    }
}
