namespace BankingApp.MAUI.Views;

public partial class ResultPage : ContentPage
{
	public ResultPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new MainPage());
    }
}