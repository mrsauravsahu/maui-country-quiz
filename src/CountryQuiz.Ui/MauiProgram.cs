using Microsoft.Extensions.Logging;

using DotNet.Meteor.HotReload.Plugin;
using CountryQuiz.ViewModels;

namespace CountryQuiz;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
#if DEBUG
			.EnableHotReload()
#endif
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainPageViewModel>();

		builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<SettingsPageViewModel>();

        builder.Services.AddTransient<QuizPage>();
        builder.Services.AddTransient<QuizPageViewModel>();

        Routing.RegisterRoute(nameof(MainPageViewModel), typeof(MainPage));
		Routing.RegisterRoute(nameof(SettingsPageViewModel), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(QuizPageViewModel), typeof(QuizPage));

        var app = builder.Build();
		return app;
	}
}
