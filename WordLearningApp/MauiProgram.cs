using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using WordLearningApp.Services.Database;
using WordLearningApp.ViewModels;
using WordLearningApp.Views;

namespace WordLearningApp
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
            // Register Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DeckPage>();
            builder.Services.AddTransient<AddDeckPage>();
            builder.Services.AddTransient<AddWordPage>();

            // Register ViewModels
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<DeckPageViewModel>();
            builder.Services.AddTransient<AddDeckViewModel>();
            builder.Services.AddTransient<AddWordViewModel>();

            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();

            return builder.Build();
        }
    }
}
