using Microsoft.Extensions.Logging;
using SQLiteTemplate.ViewModels;

namespace SQLiteTemplate
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ListPageViewModel>();
            builder.Services.AddSingleton<RecordPageViewModel>();
            builder.Services.AddSingleton<DetailPageViewModel>();

            return builder.Build();
        }
    }
}
