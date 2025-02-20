using BankingApp.Client.Interfaces;
using BankingApp.MAUI.ViewModels;

namespace BankingApp.MAUI.Views;


public partial class ReviewPage : ContentPage
{
    private readonly IAbsaBankService _absaBankService;
    private readonly IServiceProvider _serviceProvider;

    public ReviewPage(IAbsaBankService absaBankService,
        IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _absaBankService = absaBankService;
        _serviceProvider = serviceProvider;

        BindingContext = new ReviewViewModel(absaBankService, _serviceProvider);

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var viewModel = _serviceProvider.GetService<SharedViewModel>();

        if (viewModel != null)
        {
            try
            {
                var result = await _absaBankService.SubmitPaymentExecuteAsync(new Shared.RequestModel.PaymentExecuteRequestModel()
                {
                    InstructionIdentifier = viewModel.InstructionIdentifier
                });

                if (!string.IsNullOrEmpty(result.InstructionReference))
                    await Shell.Current.GoToAsync($"{nameof(ResultPage)}?result={result.InstructionReference}");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error occured", ex.Message, "OK");
                return;
            }
        }
    }
}