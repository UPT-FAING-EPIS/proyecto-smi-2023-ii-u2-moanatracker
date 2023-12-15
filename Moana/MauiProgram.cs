using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Supabase; 
using Moana.View;
using Moana.Models;

namespace Moana
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Retrieve Supabase configuration
            var supabaseConfig = builder.Configuration.GetSection("Supabase");
            var supabaseUrl = "https://aedefiwrqctkhakwuhqb.supabase.co/";
            var supabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImFlZGVmaXdycWN0a2hha3d1aHFiIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTU2MTQ4NTYsImV4cCI6MjAxMTE5MDg1Nn0.-Irt1RDGROoKmJyrNdcCUNiIuUMoZWcXP1QRDpPI0sM";


            // Initialize the Supabase client
            var supabaseClient = new Client(supabaseUrl, supabaseApiKey);
            builder.Services.AddSingleton(supabaseClient);
            builder.Services.AddTransient<AuthenticationService>();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<DetalleRecetaService>();

            // TODO: Register this client instance with your dependency injection container if you have one. 
            // This allows you to use it across your application. 
            // For example:
            // builder.Services.AddSingleton(supabaseClient);

            // Configurations
            builder.UseMauiApp<App>()
                   .UseLocalNotification()
                   .ConfigureFonts(fonts => ConfigureFonts(fonts));

            ConfigureEntryHandler();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void ConfigureFonts(Microsoft.Maui.Hosting.IFontCollection fonts)
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("ConcertOne-Regular.ttf", "ConcertOne");
            fonts.AddFont("PoppinsRegular.ttf", "Poppins");
            fonts.AddFont("fontello.ttf", "fontello");
        }

        private static void ConfigureEntryHandler()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });
        }
    }
}