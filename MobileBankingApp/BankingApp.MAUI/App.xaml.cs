namespace BankingApp.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Subscribe to unhandled exception events
            //AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            //{
            //    var ex = e.ExceptionObject as Exception;
            //    if (ex != null)
            //    {
            //        // Log the exception or show an alert
            //        Console.WriteLine($"Unhandled Exception: {ex.Message}");

            //        // Optionally, show an alert or handle the exception globally
            //        MainThread.BeginInvokeOnMainThread(async () =>
            //        {
            //            await Shell.Current.DisplayAlert("Unexpected Error", ex.Message, "OK");
            //        });
            //    }
            //};

            MainPage = new AppShell();
        }
    }
}
