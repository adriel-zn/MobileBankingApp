using BankingApp.MAUI.ViewModels;

namespace BankingApp.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(BeneficiaryViewModel beneficiaryViewModel)
        {
            InitializeComponent();
            BindingContext = beneficiaryViewModel;
        }
    }

}
