using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankingApp.MAUI.ViewModels
{
    public class ReviewViewModel : INotifyPropertyChanged
    {
        private readonly IAbsaBankService _absaBankService;
        private readonly IServiceProvider _serviceProvider;
      
        public ReviewViewModel(IAbsaBankService absaBankService, 
            IServiceProvider serviceProvider)
        {
            _absaBankService = absaBankService;
            _serviceProvider = serviceProvider;

            _ = LoadReviewedInfo();
        }

        private AccountModel _account;

        public AccountModel Account
        {
            get => _account;
            set
            {
                if (_account != value)
                {
                    _account = value;
                    OnPropertyChanged(nameof(Account));
                }
            }
        }

        private BeneficiaryModel _beneficiary;

        public BeneficiaryModel Beneficiary
        {
            get => _beneficiary;
            set
            {
                if (_beneficiary != value)
                {
                    _beneficiary = value;
                    OnPropertyChanged(nameof(Beneficiary));
                }
            }
        }

        private decimal _amount;

        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        private decimal _fee;

        public decimal Fee
        {
            get => _fee;
            set
            {
                if (_fee != value)
                {
                    _fee = value;
                    OnPropertyChanged(nameof(Fee));
                }
            }
        }


        private async Task LoadReviewedInfo()
        {
            var viewModel = _serviceProvider.GetService<SharedViewModel>();

            if (viewModel != null)
            {
                var results = await _absaBankService.PaymentInitialiseAsync();

                Beneficiary = results.Beneficiaries.FirstOrDefault(x => x.Id.Equals(viewModel.BeneficiaryId))
                    ?? new BeneficiaryModel();
                Account = results.Accounts.FirstOrDefault(x => x.Number.Equals(viewModel.AccountNumber))
                    ?? new AccountModel();

                Fee = viewModel?.FeeAmount ?? 0;
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
