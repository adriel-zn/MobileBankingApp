using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.MAUI.ViewModels;
using BankingApp.MAUI.Views;
using BankingApp.Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BankingApp.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IAbsaBankService _absaBankService;
        private readonly IServiceProvider _serviceProvider;
        public BeneficiaryModel SelectedBeneficiaryItem { get; set; }

        public MainPage(
            IAbsaBankService absaBankService,
            IServiceProvider serviceProvider
            )
        {
            InitializeComponent();

            _absaBankService = absaBankService;
            _serviceProvider = serviceProvider;

            BindingContext = new BeneficiaryViewModel(_absaBankService);


        }

        private async void ViewCell_Tapped_1(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(SelectedBeneficiaryItem?.Id))
                await DisplayAlert("Validating Beneficiary", "Beneficiary id is not valid.", "OK");

            await Shell.Current.GoToAsync($"{nameof(PaymentPage)}?beneficiaryId={SelectedBeneficiaryItem?.Id}");
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                SelectedBeneficiaryItem = (BeneficiaryModel)e.SelectedItem;
        }
    }

}
