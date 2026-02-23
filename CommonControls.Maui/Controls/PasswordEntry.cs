namespace CommonControls.Maui.Controls;

public class PasswordEntry : ContentView
{
    private const string EyeResourceName = "CommonControls.Maui.Resources.Images.cc_eye.png";
    private const string HiddenResourceName = "CommonControls.Maui.Resources.Images.cc_hidden.png";

    private static byte[]? _eyeBytes;
    private static byte[]? _hiddenBytes;

    private static ImageSource CreateDefaultShowIcon()
    {
        _eyeBytes ??= LoadEmbeddedBytes(EyeResourceName);
        return ImageSource.FromStream(() => new MemoryStream(_eyeBytes));
    }

    private static ImageSource CreateDefaultHideIcon()
    {
        _hiddenBytes ??= LoadEmbeddedBytes(HiddenResourceName);
        return ImageSource.FromStream(() => new MemoryStream(_hiddenBytes));
    }

    private static byte[] LoadEmbeddedBytes(string resourceName)
    {
        var assembly = typeof(PasswordEntry).Assembly;
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream is null) return [];
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(PasswordEntry), default(string), BindingMode.TwoWay);

    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(PasswordEntry));

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(PasswordEntry), true,
            propertyChanged: OnIsPasswordChanged);

    public static readonly BindableProperty ShowPasswordImageSourceProperty =
        BindableProperty.Create(nameof(ShowPasswordImageSource), typeof(ImageSource), typeof(PasswordEntry),
            propertyChanged: OnImageSourceChanged);

    public static readonly BindableProperty HidePasswordImageSourceProperty =
        BindableProperty.Create(nameof(HidePasswordImageSource), typeof(ImageSource), typeof(PasswordEntry),
            propertyChanged: OnImageSourceChanged);

    public static readonly BindableProperty ImageHeightProperty =
        BindableProperty.Create(nameof(ImageHeight), typeof(double), typeof(PasswordEntry), 24.0,
            propertyChanged: OnImageSizeChanged);

    public static readonly BindableProperty ImageWidthProperty =
        BindableProperty.Create(nameof(ImageWidth), typeof(double), typeof(PasswordEntry), 24.0,
            propertyChanged: OnImageSizeChanged);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(double), typeof(PasswordEntry), 14.0);

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(PasswordEntry));

    public static readonly BindableProperty PlaceholderColorProperty =
        BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(PasswordEntry));

    private readonly BorderlessEntry _entry;
    private readonly ImageButton _toggleImageButton;

    public PasswordEntry()
    {
        _entry = new BorderlessEntry
        {
            IsPassword = true,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Fill,
        };

        _entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), source: this, mode: BindingMode.TwoWay));
        _entry.SetBinding(Entry.PlaceholderProperty, new Binding(nameof(Placeholder), source: this));
        _entry.SetBinding(Entry.FontSizeProperty, new Binding(nameof(FontSize), source: this));
        _entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(TextColor), source: this));
        _entry.SetBinding(Entry.PlaceholderColorProperty, new Binding(nameof(PlaceholderColor), source: this));

        _toggleImageButton = new ImageButton
        {
            Source = CreateDefaultShowIcon(),
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.End,
            BackgroundColor = Colors.Transparent,
            Padding = 0,
            Margin = 0,
            Aspect = Aspect.AspectFit,
            HeightRequest = 24,
            WidthRequest = 24,
            MinimumHeightRequest = 0,
            MinimumWidthRequest = 0,
        };
        _toggleImageButton.Clicked += OnTogglePasswordClicked;

        var grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Auto),
            },
            ColumnSpacing = 8,
        };

        grid.Add(_entry, 0);
        grid.Add(_toggleImageButton, 1);

        Content = grid;
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public ImageSource ShowPasswordImageSource
    {
        get => (ImageSource)GetValue(ShowPasswordImageSourceProperty);
        set => SetValue(ShowPasswordImageSourceProperty, value);
    }

    public ImageSource HidePasswordImageSource
    {
        get => (ImageSource)GetValue(HidePasswordImageSourceProperty);
        set => SetValue(HidePasswordImageSourceProperty, value);
    }

    public double ImageHeight
    {
        get => (double)GetValue(ImageHeightProperty);
        set => SetValue(ImageHeightProperty, value);
    }

    public double ImageWidth
    {
        get => (double)GetValue(ImageWidthProperty);
        set => SetValue(ImageWidthProperty, value);
    }

    public new double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public Color PlaceholderColor
    {
        get => (Color)GetValue(PlaceholderColorProperty);
        set => SetValue(PlaceholderColorProperty, value);
    }

    private void OnTogglePasswordClicked(object? sender, EventArgs e)
    {
        IsPassword = !IsPassword;
    }

    private static void OnIsPasswordChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is PasswordEntry control)
        {
            control._entry.IsPassword = (bool)newValue;
            control.UpdateToggleIcon();
        }
    }

    private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is PasswordEntry control)
        {
            control.UpdateToggleIcon();
        }
    }

    private static void OnImageSizeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is PasswordEntry control)
        {
            control._toggleImageButton.HeightRequest = control.ImageHeight;
            control._toggleImageButton.WidthRequest = control.ImageWidth;
            control._toggleImageButton.MinimumHeightRequest = control.ImageHeight;
            control._toggleImageButton.MinimumWidthRequest = control.ImageWidth;
        }
    }

    private void UpdateToggleIcon()
    {
        _toggleImageButton.Source = IsPassword
            ? (ShowPasswordImageSource ?? CreateDefaultShowIcon())
            : (HidePasswordImageSource ?? CreateDefaultHideIcon());
    }
}
