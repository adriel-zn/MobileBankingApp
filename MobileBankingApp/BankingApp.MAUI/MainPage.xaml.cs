using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.MAUI.ViewModels;
using BankingApp.MAUI.Views;
using BankingApp.Shared.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BankingApp.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IAbsaBankService _absaBankService;

        public MainPage(IAbsaBankService absaBankService)
        {
            _absaBankService = absaBankService;
            InitializeComponent();
            BindingContext = new BeneficiaryViewModel(_absaBankService);
        }

        private async void ViewCell_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PaymentPage));
        }
    }

}
