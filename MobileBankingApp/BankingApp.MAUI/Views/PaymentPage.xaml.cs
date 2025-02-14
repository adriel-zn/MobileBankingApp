using BankingApp.Client.Interfaces;
using BankingApp.MAUI.ViewModels;
using BankingApp.Shared.Models;

namespace BankingApp.MAUI.Views;

public partial class PaymentPage : ContentPage
{
    private readonly IAbsaBankService _absaBankService;
    private readonly IServiceProvider _serviceProvider;

    public AccountModel SelectedAccountItem { get; set; }
    public decimal FeeAmount { get; set; }

    public PaymentPage(IAbsaBankService absaBankService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _absaBankService = absaBankService;
        _serviceProvider = serviceProvider;

        BindingContext = new AccountViewModel(_absaBankService);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var viewModel = _serviceProvider.GetService<SharedViewModel>();


        if (SelectedAccountItem == null || SelectedAccountItem?.Number == null)
        {
            DisplayAlert("Validated Account", "Account has not been selected.", "OK");
            await Shell.Current.Navigation.PopToRootAsync();
            return;
        }

        if (string.IsNullOrEmpty(FeeAmount.ToString()))
        {
            DisplayAlert("Validated Account", "Fee amount has not been entered.", "OK");
            await Shell.Current.Navigation.PopToRootAsync();
            return;
        }


        var result = _absaBankService.PaymentReviewAsync(new Shared.RequestModel.PaymentReviewRequestModel()
        {
            AccountNumber = SelectedAccountItem.Number,
            Amount = FeeAmount,
            BeneficiaryId = viewModel?.BeneficiaryId
        });

        await Shell.Current.GoToAsync(nameof(ReviewPage));
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker currencyPicker = (Picker)sender;
        int selectedIndex = currencyPicker.SelectedIndex;

        if (selectedIndex != -1)
        {
            SelectedAccountItem = currencyPicker.SelectedItem as AccountModel;
        }
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(((Entry)sender).Text))
            FeeAmount = Convert.ToDecimal(((Entry)sender).Text);
    }
}