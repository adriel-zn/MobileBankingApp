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
    public class BeneficiaryViewModel: INotifyPropertyChanged
    {
        readonly IList<BeneficiaryModel>? sources;

        BeneficiaryModel? selectedBeneficiary;

        public ObservableCollection<BeneficiaryModel>? Beneficiaries { get; private set; }

        public BeneficiaryModel SelectedBeneficiary
        {
            get => selectedBeneficiary;
            set
            {
                if (selectedBeneficiary != value)
                {
                    selectedBeneficiary = value;
                }
            }
        }

        public BeneficiaryViewModel()
        {
            sources = new List<BeneficiaryModel>();
            LoadBeneficiaryCollection();

            SelectedBeneficiary = Beneficiaries.Skip(3).FirstOrDefault();
            OnPropertyChanged("SelectedBeneficiary");

        }

        void LoadBeneficiaryCollection()
        {
            sources.Add(new BeneficiaryModel
            {
                Name = "Baboon"
            });

            sources.Add(new BeneficiaryModel
            {
                Name = "Monkey"
            });

            Beneficiaries = new ObservableCollection<BeneficiaryModel>(sources);
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
