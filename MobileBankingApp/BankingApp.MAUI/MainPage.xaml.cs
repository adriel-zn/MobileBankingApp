using System.Collections.ObjectModel;
using System.ComponentModel;
using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.MAUI.ViewModels;
using BankingApp.Shared.Models;

namespace BankingApp.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IAbsaBankService _absaBankService;
        public ObservableCollection<BeneficiaryModel> Items { get; set; }

        public MainPage(IAbsaBankService absaBankService)
        {
            InitializeComponent();
            _absaBankService = absaBankService;
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadBeneficiaries();
        }
        private async Task LoadBeneficiaries()
        {
            Items = (ObservableCollection<BeneficiaryModel>)await _absaBankService.PaymentInitialiseAsync();
        }

    }

}
