namespace BankingApp.MAUI.Views;

public partial class ReviewPage : ContentPage
{
	public ReviewPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ResultPage));
    }
}