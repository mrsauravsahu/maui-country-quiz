﻿using Microsoft.Extensions.Logging;

using DotNet.Meteor.HotReload.Plugin;
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

		Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));


        return builder.Build();
	}
}