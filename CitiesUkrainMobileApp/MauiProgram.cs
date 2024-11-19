using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static System.Formats.Asn1.AsnWriter;

namespace CitiesUkrainMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiMaps();
#if DEBUG
            builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton<SqliteConnectionFactory>();
            var app = builder.Build();
            return app;
        }
    }
}
