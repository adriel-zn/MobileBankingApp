using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.MAUI.ViewModels;
using BankingApp.MAUI.Views;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BankingApp.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IAbsaBankService _absaBankService;

        public MainPage(IAbsaBankService absaBankService)
        {
            InitializeComponent();

            _absaBankService = absaBankService;


            //LoadBeneficiaries();

            //BindingContext = new BeneficiaryViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ViewCell_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PaymentPage));
        }


        private async void LoadBeneficiaries()
        {
            //var result = await _absaBankService.PaymentInitialiseAsync();


        }
    }

}
