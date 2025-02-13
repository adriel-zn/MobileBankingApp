using BankingApp.MAUI.ViewModels;

namespace BankingApp.MAUI.Views;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
        BindingContext = new AccountViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ReviewPage));
    }
}