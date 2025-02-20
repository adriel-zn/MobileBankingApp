using BankingApp.Client.Interfaces;
using BankingApp.MAUI.ViewModels;
using BankingApp.Shared.Models;

namespace BankingApp.MAUI.Views;

[QueryProperty(nameof(BeneficiaryId), "beneficiaryId")]
public partial class PaymentPage : ContentPage
{
    private string? _beneficiaryId;

    private readonly IAbsaBankService _absaBankService;
    private readonly IServiceProvider _serviceProvider;

    public AccountModel SelectedAccountItem { get; set; }
    public decimal FeeAmount { get; set; }

    public string? BeneficiaryId
    {
        get => _beneficiaryId;
        set
        {
            _beneficiaryId = value;
            OnPropertyChanged(nameof(BeneficiaryId));
        }
    }

    public PaymentPage(IAbsaBankService absaBankService,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _absaBankService = absaBankService;
        _serviceProvider = serviceProvider;

        BindingContext = new AccountViewModel(_absaBankService);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (_beneficiaryId == null)
        {
            await DisplayAlert("Validated Beneficiary", "Error occurred when selecting Beneficiary.", "OK");
            await Shell.Current.Navigation.PopToRootAsync();
        }


        var viewModel = _serviceProvider.GetService<SharedViewModel>();

        if (SelectedAccountItem == null || SelectedAccountItem?.Number == null)
        {
            await DisplayAlert("Validated Account", "Account has not been selected.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(FeeAmount.ToString()))
        {
            await DisplayAlert("Validated Account", "Fee amount has not been entered.", "OK");
            return;
        }

        try
        {
            var result = await _absaBankService.SubmitPaymentReviewAsync(new Shared.RequestModel.PaymentReviewRequestModel()
            {
                AccountNumber = SelectedAccountItem.Number,
                Amount = FeeAmount,
                BeneficiaryId = BeneficiaryId
            });

            if (viewModel == null) viewModel = new SharedViewModel();

            viewModel.BeneficiaryId = BeneficiaryId;
            viewModel.AccountNumber = SelectedAccountItem.Number;
            viewModel.FeeAmount = result.Fees;
            viewModel.InstructionIdentifier = result.InstructionIdentifier;

            await Shell.Current.GoToAsync(nameof(ReviewPage));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error occured", ex.Message, "OK");
            return;
        }


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