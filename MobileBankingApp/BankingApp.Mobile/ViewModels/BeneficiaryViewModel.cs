using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BankingApp.Shared;

namespace BankingApp.Mobile.ViewModels
{
    public class BeneficiaryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Beneficiary> _beneficiaries;
        public ObservableCollection<Beneficiary> Beneficiaries
        {
            get => _beneficiaries;
            set
            {
                _beneficiaries = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Beneficiary)));
            }
        }

        public ICommand LoadBeneficiariesCommand { get; }

        public BeneficiaryViewModel()
        {
            Beneficiaries = new ObservableCollection<Beneficiary>();
            LoadBeneficiariesCommand = new Command(LoadBeneficiaries);
        }

        private void LoadBeneficiaries()
        {
            Beneficiaries.Add(new Beneficiary { Name = "Laptop" });
            Beneficiaries.Add(new Beneficiary { Name = "Phone" });
        }
    }
}
