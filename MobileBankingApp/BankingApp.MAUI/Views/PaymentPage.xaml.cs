using BankingApp.MAUI.ViewModels;

namespace BankingApp.MAUI.Views;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
        BindingContext = new AccountViewModel();
    }
}