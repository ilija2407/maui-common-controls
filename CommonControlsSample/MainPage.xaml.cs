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

        EmailEntry.TextChanged += OnEmailTextChanged;
        PasswordValidationEntry.TextChanged += OnPasswordTextChanged;
    }

    private void OnEmailTextChanged(object? sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue ?? string.Empty;
        EmailEntry.IsValid = IsValidEmail(text);
    }

    private void OnPasswordTextChanged(object? sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue ?? string.Empty;
        PasswordValidationEntry.IsValid = text.Length >= 8;
    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return false;
        var atIndex = email.IndexOf('@');
        if (atIndex <= 0) return false;
        var dotIndex = email.LastIndexOf('.');
        return dotIndex > atIndex + 1 && dotIndex < email.Length - 1;
    }
}
