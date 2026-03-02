namespace CommonControlsSample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BusyDemoStateButton.Command = new Command(async () =>
        {
            BusyDemoStateButton.IsBusy = true;
            ShareItStateButton.IsEnabled = false;
            await Task.Delay(2500);
            BusyDemoStateButton.IsBusy = false;
            ShareItStateButton.IsEnabled = true;
        });
    }
}
