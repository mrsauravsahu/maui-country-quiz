using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CountryQuiz.ViewModels
{
	public partial class MainPageViewModel: ObservableObject
	{
		public MainPageViewModel()
		{

		}

		[RelayCommand]
		public void NavigateToSettingsPage()
		{
			//AppShell
		}


	}
}

