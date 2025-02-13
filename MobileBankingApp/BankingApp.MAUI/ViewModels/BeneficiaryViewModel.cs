using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.Shared.Models;

namespace BankingApp.MAUI.ViewModels
{
    public class BeneficiaryViewModel : INotifyPropertyChanged
    {
        private readonly IAbsaBankService _absaBankService;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<BeneficiaryModel> _beneficiaries;
        public ObservableCollection<BeneficiaryModel> Beneficiaries
        {
            get => _beneficiaries;
            set
            {
                _beneficiaries = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BeneficiaryModel)));
            }
        }
        public BeneficiaryViewModel()
        {
            // Default constructor required for MAUI to initialize
        }

        public BeneficiaryViewModel(IAbsaBankService absaBankService)
        {
            _absaBankService = absaBankService;

            Beneficiaries = new ObservableCollection<BeneficiaryModel>();

            Task task = LoadProducts();
        }

        private async Task LoadProducts()
        {
            Beneficiaries.Clear();

            Beneficiaries = (ObservableCollection<BeneficiaryModel>)await _absaBankService.PaymentInitialiseAsync();
        }
    }
}
