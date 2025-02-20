namespace BankingApp.MAUI.Views;

[QueryProperty(nameof(Result), "result")]
public partial class ResultPage : ContentPage
{
    private string? _result; 


    public string? Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged(nameof(Result));
        }
    }



    public ResultPage()
	{
		InitializeComponent();
        BindingContext = this;

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopToRootAsync();
    }
}