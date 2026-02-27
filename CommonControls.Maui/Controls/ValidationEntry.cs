using Microsoft.Maui.Controls.Shapes;

namespace CommonControls.Maui.Controls;

public class ValidationEntry : ContentView
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ValidationEntry), default(string), BindingMode.TwoWay);

    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ValidationEntry));

    public static readonly BindableProperty IsValidProperty =
        BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ValidationEntry), true,
            propertyChanged: OnIsValidChanged);

    public static readonly BindableProperty ErrorMessageProperty =
        BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(ValidationEntry), string.Empty,
            propertyChanged: OnErrorMessageChanged);

    public static readonly BindableProperty ErrorColorProperty =
        BindableProperty.Create(nameof(ErrorColor), typeof(Color), typeof(ValidationEntry), Colors.Red);

    public static readonly BindableProperty ErrorFontSizeProperty =
        BindableProperty.Create(nameof(ErrorFontSize), typeof(double), typeof(ValidationEntry), 12.0);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(double), typeof(ValidationEntry), 14.0);

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ValidationEntry));

    public static readonly BindableProperty PlaceholderColorProperty =
        BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(ValidationEntry));

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ValidationEntry), Colors.Transparent,
            propertyChanged: OnBorderColorChanged);

    public static readonly BindableProperty ErrorBorderColorProperty =
        BindableProperty.Create(nameof(ErrorBorderColor), typeof(Color), typeof(ValidationEntry), Colors.Red,
            propertyChanged: OnBorderColorChanged);

    public static readonly BindableProperty BorderVisibleProperty =
        BindableProperty.Create(nameof(BorderVisible), typeof(bool), typeof(ValidationEntry), false,
            propertyChanged: OnBorderVisibleChanged);

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(ValidationEntry), 0.0,
            propertyChanged: OnCornerRadiusChanged);

    public static readonly BindableProperty SeparatorVisibleProperty =
        BindableProperty.Create(nameof(SeparatorVisible), typeof(bool), typeof(ValidationEntry), false,
            propertyChanged: OnSeparatorVisibleChanged);

    public static readonly BindableProperty ErrorSeparatorColorProperty =
        BindableProperty.Create(nameof(ErrorSeparatorColor), typeof(Color), typeof(ValidationEntry), Colors.Red,
            propertyChanged: OnSeparatorColorChanged);

    public static readonly BindableProperty KeyboardProperty =
        BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(ValidationEntry), Keyboard.Default);

    private readonly BorderlessEntry _entry;
    private readonly Label _errorLabel;
    private readonly BoxView _separator;
    private readonly Border _entryBorder;

    public ValidationEntry()
    {
        _entry = new BorderlessEntry
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Fill,
        };

        _entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), source: this, mode: BindingMode.TwoWay));
        _entry.SetBinding(Entry.PlaceholderProperty, new Binding(nameof(Placeholder), source: this));
        _entry.SetBinding(Entry.FontSizeProperty, new Binding(nameof(FontSize), source: this));
        _entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(TextColor), source: this));
        _entry.SetBinding(Entry.PlaceholderColorProperty, new Binding(nameof(PlaceholderColor), source: this));
        _entry.SetBinding(Entry.KeyboardProperty, new Binding(nameof(Keyboard), source: this));
        _entry.TextChanged += (s, e) => TextChanged?.Invoke(this, e);

        _errorLabel = new Label
        {
            IsVisible = false,
            HorizontalOptions = LayoutOptions.Fill,
        };

        _errorLabel.SetBinding(Label.TextColorProperty, new Binding(nameof(ErrorColor), source: this));
        _errorLabel.SetBinding(Label.FontSizeProperty, new Binding(nameof(ErrorFontSize), source: this));

        _separator = new BoxView
        {
            HeightRequest = 1,
            HorizontalOptions = LayoutOptions.Fill,
            IsVisible = false,
        };

        _entryBorder = new Border
        {
            StrokeThickness = 1,
            Stroke = new SolidColorBrush(Colors.Transparent),
            StrokeShape = new RoundRectangle { CornerRadius = 0 },
            Padding = new Thickness(8, 4),
            Content = new VerticalStackLayout
            {
                Spacing = 2,
                Children =
                {
                    _entry,
                    _separator,
                    _errorLabel,
                },
            },
        };

        Content = _entryBorder;
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

    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public Color ErrorColor
    {
        get => (Color)GetValue(ErrorColorProperty);
        set => SetValue(ErrorColorProperty, value);
    }

    public double ErrorFontSize
    {
        get => (double)GetValue(ErrorFontSizeProperty);
        set => SetValue(ErrorFontSizeProperty, value);
    }

    public double FontSize
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

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public Color ErrorBorderColor
    {
        get => (Color)GetValue(ErrorBorderColorProperty);
        set => SetValue(ErrorBorderColorProperty, value);
    }

    public bool BorderVisible
    {
        get => (bool)GetValue(BorderVisibleProperty);
        set => SetValue(BorderVisibleProperty, value);
    }

    public double CornerRadius
    {
        get => (double)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public bool SeparatorVisible
    {
        get => (bool)GetValue(SeparatorVisibleProperty);
        set => SetValue(SeparatorVisibleProperty, value);
    }

    public Color ErrorSeparatorColor
    {
        get => (Color)GetValue(ErrorSeparatorColorProperty);
        set => SetValue(ErrorSeparatorColorProperty, value);
    }

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public event EventHandler<TextChangedEventArgs>? TextChanged;

    private static void OnIsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ValidationEntry control)
        {
            control.UpdateErrorState();
        }
    }

    private static void OnErrorMessageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ValidationEntry control)
        {
            control._errorLabel.Text = (string)newValue;
        }
    }

    private static void OnBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ValidationEntry control)
        {
            control.UpdateErrorState();
        }
    }

    private static void OnBorderVisibleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ValidationEntry control)
        {
            control.UpdateErrorState();
        }
    }

    private static void OnCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ValidationEntry control)
        {
            control._entryBorder.StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius((double)newValue) };
        }
    }

    private static void OnSeparatorVisibleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ValidationEntry control)
        {
            control.UpdateErrorState();
        }
    }

    private static void OnSeparatorColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ValidationEntry control)
        {
            control.UpdateErrorState();
        }
    }

    private void UpdateErrorState()
    {
        _errorLabel.IsVisible = !IsValid;

        _separator.IsVisible = SeparatorVisible && !IsValid;
        _separator.Color = ErrorSeparatorColor;

        var strokeColor = BorderVisible ? (!IsValid ? ErrorBorderColor : BorderColor) : Colors.Transparent;
        _entryBorder.Stroke = new SolidColorBrush(strokeColor);
    }
}
