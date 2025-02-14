using BankingApp.Shared.Models;
using BankingApp.Shared.RequestModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.MAUI.ViewModels
{
    public class SharedViewModel : INotifyPropertyChanged
    {
        private string _beneficiaryId;
        public string BeneficiaryId
        {
            get => _beneficiaryId;
            set
            {
                _beneficiaryId = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
