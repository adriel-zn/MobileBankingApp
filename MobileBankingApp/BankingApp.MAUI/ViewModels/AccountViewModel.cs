﻿using BankingApp.Client.Interfaces;
using BankingApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.MAUI.ViewModels
{
    public class AccountViewModel :INotifyPropertyChanged
    {
        private readonly IAbsaBankService _absaBankService;

        public ObservableCollection<AccountModel> Items { get; set; } = new ObservableCollection<AccountModel>();

        public AccountViewModel(IAbsaBankService absaBankService)
        {
            _absaBankService = absaBankService;

            _ = LoadAccounts();
        }

        private async Task LoadAccounts()
        {
            var results = await _absaBankService.PaymentInitialiseAsync();

            Items.Clear();

            foreach (var item in results.Accounts)
            {
                Items.Add(item);
            }

        }

        private AccountModel _selectedAccountItem;
        public AccountModel SelectedAccountItem
        {
            get => _selectedAccountItem;
            set
            {
                if (_selectedAccountItem != value)
                {
                    _selectedAccountItem = value;
                    OnPropertyChanged();
                }
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
