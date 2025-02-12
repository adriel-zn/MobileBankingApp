using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BankingApp.Shared;
using BankingApp.Shared.Models;

namespace BankingApp.Mobile.ViewModels
{
    public class BeneficiaryViewModel : INotifyPropertyChanged
    {
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

        public ICommand LoadBeneficiariesCommand { get; }

        public BeneficiaryViewModel()
        {
            Beneficiaries = new ObservableCollection<BeneficiaryModel>();
            LoadBeneficiariesCommand = new Command(LoadBeneficiaries);
        }

        private void LoadBeneficiaries()
        {
            Beneficiaries.Add(new BeneficiaryModel { Name = "Laptop" });
            Beneficiaries.Add(new BeneficiaryModel { Name = "Phone" });
        }
    }
}
