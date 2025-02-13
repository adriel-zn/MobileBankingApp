using BankingApp.MAUI.ViewModels;
using BankingApp.MAUI.Views;
using System.Threading.Tasks;

namespace BankingApp.MAUI
{
    public partial class MainPage : ContentPage
    {
        private ViewCell m_LastSelectViewCell;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new BeneficiaryViewModel();
        }

        private async void ViewCell_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PaymentPage));
        }
    }

}
