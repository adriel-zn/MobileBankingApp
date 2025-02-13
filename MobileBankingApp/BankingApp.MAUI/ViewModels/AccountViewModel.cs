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
        readonly IList<AccountModel>? sources;

        AccountModel? selectedAccount;

        public ObservableCollection<AccountModel>? Accounts { get; private set; }

        public AccountModel SelectedAccount
        {
            get => selectedAccount;
            set
            {
                if (selectedAccount != value)
                {
                    selectedAccount = value;
                }
            }
        }

        public AccountViewModel()
        {
            sources = new List<AccountModel>();
            LoadAccountCollection();

            SelectedAccount = Accounts.Skip(3).FirstOrDefault();
            OnPropertyChanged("SelectedAccount");

        }

        void LoadAccountCollection()
        {
            sources.Add(new AccountModel
            {
                Number = "1111111"
            });

            sources.Add(new AccountModel
            {
                Number = "33333"
            });

            Accounts = new ObservableCollection<AccountModel>(sources);
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
