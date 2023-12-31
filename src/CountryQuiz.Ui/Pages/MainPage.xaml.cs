﻿using CountryQuiz.ViewModels;
using Microsoft.Maui.Controls;

namespace CountryQuiz;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}

    async void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {
        var rotator = 1;
        uint timeMs = 24000;
        while (true)
        {
            await Task.WhenAny(
                CountryLabel1.TranslateTo(rotator * Application.Current.MainPage.Width, CountryLabel1.Y, timeMs, Easing.Linear),
                CountryLabel2.TranslateTo(-1 * rotator * Application.Current.MainPage.Width, CountryLabel1.Y, timeMs, Easing.Linear),
                CountryLabel3.TranslateTo(rotator * Application.Current.MainPage.Width, CountryLabel1.Y, timeMs, Easing.Linear)
            );
            rotator *= -1;
        }
    }

    async void SettingsButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(SettingsPage));
    }
}
