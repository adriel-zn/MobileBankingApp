using BankingApp.Mobile.ViewModels;

namespace BankingApp.Mobile.Views;

public partial class BeneficiaryPage : ContentPage
{
	public BeneficiaryPage(BeneficiaryViewModel beneficiaryViewModel)
	{
        InitializeComponent();
        BindingContext = beneficiaryViewModel;
    }    
}