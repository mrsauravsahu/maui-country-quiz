namespace CountryQuiz;

public partial class BalloonPage : ContentPage
{
  public BalloonPage()
  {
    InitializeComponent();
  }

  async void Button_Clicked(System.Object sender, System.EventArgs e)
  {
    await Balloon.TranslateTo(0, Balloon.Y - 20, 250);
    await Balloon.TranslateTo(0, 500, 5000);
  }

  async void StartButton_Clicked(System.Object sender, System.EventArgs e)
  {
    await Balloon.TranslateTo(0, 500, 5000);
  }
}
