// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Apps.Mobile.Brokers.Loggings;
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

            mauiAppBuilder.Services.AddTransient<
                ILoggingBroker,
                LoggingBroker>();

#if DEBUG
    		mauiAppBuilder.Services.AddBlazorWebViewDeveloperTools();
    		mauiAppBuilder.Logging.AddDebug();
#endif

            return mauiAppBuilder.Build();
        }
    }
}
