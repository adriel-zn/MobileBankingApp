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
    public class MainViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<BeneficiaryModel> Items { get; set; }

        public MainViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
