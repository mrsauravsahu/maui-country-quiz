using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CountryQuiz.ViewModels
{
	public partial class MainPageViewModel: ObservableObject
	{
		[RelayCommand]
		public async Task NavigateToSettingsPage()
		{
			await Shell.Current.GoToAsync(nameof(SettingsPageViewModel));
		}

        [RelayCommand]
        public async Task StartQuiz()
        {
            await Shell.Current.GoToAsync(nameof(QuizPageViewModel));
        }
    }
}

