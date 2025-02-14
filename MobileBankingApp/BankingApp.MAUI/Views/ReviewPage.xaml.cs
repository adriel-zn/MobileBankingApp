using BankingApp.Client.Interfaces;
using BankingApp.MAUI.ViewModels;

namespace BankingApp.MAUI.Views;

public partial class ReviewPage : ContentPage
{
    private readonly IAbsaBankService _absaBankService;
    private readonly IServiceProvider _serviceProvider;

    public ReviewPage(IAbsaBankService absaBankService, IServiceProvider serviceProvider)
	{
		InitializeComponent();

        _absaBankService = absaBankService;
        _serviceProvider = serviceProvider;

        BindingContext = new ReviewViewModel(absaBankService);

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ResultPage));
    }
}