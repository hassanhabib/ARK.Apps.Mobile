// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.IO;
using System.Reflection;
using ARK.Apps.Mobile.Brokers.Arks;
using ARK.Apps.Mobile.Brokers.Loggings;
using ARK.Apps.Mobile.Services.Foundations;
using ARK.Apps.Mobile.Services.Views.ArkViews;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Syncfusion.Blazor;

namespace ARK.Apps.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder mauiAppBuilder =
                MauiApp.CreateBuilder();

            Assembly assembly =
                Assembly.GetExecutingAssembly();

            mauiAppBuilder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

            mauiAppBuilder.Services.AddMauiBlazorWebView();
            mauiAppBuilder.Services.AddSyncfusionBlazor();
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

            RegisterAppSettings(
                mauiAppBuilder,
                assembly,
                filePath: "ARK.Apps.Mobile.appsettings.json");

#if DEBUG
            mauiAppBuilder.Services.AddBlazorWebViewDeveloperTools();
            mauiAppBuilder.Logging.AddDebug();
#endif

            return mauiAppBuilder.Build();
        }


        private static void RegisterAppSettings(
            MauiAppBuilder mauiAppBuilder,
            Assembly assembly,
            string filePath)
        {
            using Stream appSettingsStream = 
                assembly.GetManifestResourceStream(filePath);

            if(appSettingsStream is not null)
            {
                mauiAppBuilder.Configuration.AddJsonStream(
                    appSettingsStream);
            }
        }
    }
}
