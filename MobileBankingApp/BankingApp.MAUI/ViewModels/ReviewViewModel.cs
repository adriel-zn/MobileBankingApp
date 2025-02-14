using BankingApp.Client.Interfaces;
using BankingApp.Client.Services;
using BankingApp.Shared.Models;
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

        public ObservableCollection<AccountBeneficiaryModel> Items { get; set; } = new ObservableCollection<AccountBeneficiaryModel>();

        public ReviewViewModel(IAbsaBankService absaBankService)
        {
            _absaBankService = absaBankService;

            _ = LoadReviewedInfo();
        }

        private async Task LoadReviewedInfo()
        {
            var results = await _absaBankService.PaymentInitialiseAsync();

            Items.Clear();

            //foreach (var item in results)
            //{
            //    Items.Add(item);
            //}

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
