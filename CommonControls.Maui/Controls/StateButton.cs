using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;

namespace CommonControls.Maui.Controls;

public partial class StateButton : ContentView, IStateButton
{
    private readonly Border _border;
    private readonly Grid _rootGrid;
    private readonly Image _image;
    private readonly Label _label;
    private readonly BoxView _divider;
    private readonly ActivityIndicator _activityIndicator;
    private Layout _contentStack;

    // Shadows VisualElement.BackgroundColor so the Border (not the ContentView) receives the colour,
    // keeping the rounded shape intact at every corner.
    public static new readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(StateButton), Colors.Transparent,
            propertyChanged: OnButtonBackgroundColorChanged);

    public static readonly BindableProperty IsBusyProperty =
        BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(StateButton), false,
            propertyChanged: OnIsBusyChanged);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(StateButton), string.Empty,
            propertyChanged: OnTextChanged);

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(StateButton), Colors.White,
            propertyChanged: OnTextColorChanged);

    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(StateButton), null,
            propertyChanged: OnImageSourceChanged);

    public static readonly BindableProperty ImagePositionProperty =
        BindableProperty.Create(nameof(ImagePosition), typeof(ButtonImagePosition), typeof(StateButton),
            ButtonImagePosition.Start, propertyChanged: OnImagePositionChanged);

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(StateButton), null);

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(StateButton), null);

    public static readonly BindableProperty AnimationTypeProperty =
        BindableProperty.Create(nameof(AnimationType), typeof(ButtonAnimationType), typeof(StateButton),
            ButtonAnimationType.Scale);

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(StateButton), 8.0,
            propertyChanged: OnCornerRadiusChanged);

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(StateButton), Colors.Transparent,
            propertyChanged: OnBorderColorChanged);

    public static readonly BindableProperty ShowDividerProperty =
        BindableProperty.Create(nameof(ShowDivider), typeof(bool), typeof(StateButton), false,
            propertyChanged: OnShowDividerChanged);

    public static readonly BindableProperty DividerColorProperty =
        BindableProperty.Create(nameof(DividerColor), typeof(Color), typeof(StateButton), Colors.White,
            propertyChanged: OnDividerColorChanged);

    public static readonly BindableProperty BackgroundBrushProperty =
        BindableProperty.Create(nameof(BackgroundBrush), typeof(Brush), typeof(StateButton), null,
            propertyChanged: OnBackgroundBrushChanged);

    public static readonly BindableProperty FontAttributesProperty =
        BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(StateButton), FontAttributes.None,
            propertyChanged: OnFontAttributesChanged);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(double), typeof(StateButton), 14.0,
            propertyChanged: OnFontSizeChanged);

    public new Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public Brush? BackgroundBrush
    {
        get => (Brush?)GetValue(BackgroundBrushProperty);
        set => SetValue(BackgroundBrushProperty, value);
    }

    public FontAttributes FontAttributes
    {
        get => (FontAttributes)GetValue(FontAttributesProperty);
        set => SetValue(FontAttributesProperty, value);
    }

    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public ImageSource? ImageSource
    {
        get => (ImageSource?)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public ButtonImagePosition ImagePosition
    {
        get => (ButtonImagePosition)GetValue(ImagePositionProperty);
        set => SetValue(ImagePositionProperty, value);
    }

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public ButtonAnimationType AnimationType
    {
        get => (ButtonAnimationType)GetValue(AnimationTypeProperty);
        set => SetValue(AnimationTypeProperty, value);
    }

    public double CornerRadius
    {
        get => (double)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public bool ShowDivider
    {
        get => (bool)GetValue(ShowDividerProperty);
        set => SetValue(ShowDividerProperty, value);
    }

    public Color DividerColor
    {
        get => (Color)GetValue(DividerColorProperty);
        set => SetValue(DividerColorProperty, value);
    }

    public StateButton()
    {
        _image = new Image
        {
            Aspect = Aspect.AspectFit,
            IsVisible = false,
            VerticalOptions = LayoutOptions.Center,
            HeightRequest = 20,
            WidthRequest = 20,
        };

        _label = new Label
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        _activityIndicator = new ActivityIndicator
        {
            IsVisible = false,
            IsRunning = false,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            HeightRequest = 20,
            WidthRequest = 20,
        };

        _activityIndicator.SetBinding(ActivityIndicator.ColorProperty,
            new Binding(nameof(TextColor), source: this));

        _divider = new BoxView
        {
            WidthRequest = 1,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Center,
            IsVisible = false,
            Color = Colors.White,
        };

        _contentStack = BuildContentStack(ButtonImagePosition.Start);

        _rootGrid = new Grid();
        _rootGrid.Add(_contentStack);
        _rootGrid.Add(_activityIndicator);

        _border = new Border
        {
            Content = _rootGrid,
            Stroke = new SolidColorBrush(Colors.Transparent),
            StrokeThickness = 1,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(8) },
            Padding = new Thickness(12, 8),
        };

        Content = _border;

        var tap = new TapGestureRecognizer();
        tap.Tapped += OnTapped;
        GestureRecognizers.Add(tap);

        // PointerGestureRecognizer gives us touch-down feedback without competing with
        // TapGestureRecognizer (both are MAUI-level and cooperate on iOS and Android).
        var pointer = new PointerGestureRecognizer();
        pointer.PointerPressed  += (_, _) => PlayTouchDown();
        pointer.PointerReleased += (_, _) => PlayTouchUp();
        pointer.PointerExited   += (_, _) => PlayTouchUp();
        GestureRecognizers.Add(pointer);
    }

    private Layout BuildContentStack(ButtonImagePosition position)
    {
        // Detach children from their current parent so they can be re-hosted in the new stack.
        if (_image.Parent is Layout imageParent) imageParent.Remove(_image);
        if (_label.Parent is Layout labelParent) labelParent.Remove(_label);
        if (_divider.Parent is Layout dividerParent) dividerParent.Remove(_divider);

        return position is ButtonImagePosition.Top or ButtonImagePosition.Bottom
            ? BuildVerticalStack(position)
            : BuildHorizontalStack(position);
    }

    private Layout BuildHorizontalStack(ButtonImagePosition position)
    {
        var grid = new Grid
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Fill,
            ColumnSpacing = 8,
        };

        _label.HorizontalOptions = LayoutOptions.Center;
        _label.VerticalOptions = LayoutOptions.Center;

        if (position == ButtonImagePosition.Start)
        {
            grid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition(GridLength.Auto),
                new ColumnDefinition(GridLength.Auto),
                new ColumnDefinition(GridLength.Star),
            };
            Grid.SetColumn(_image, 0);
            Grid.SetColumn(_divider, 1);
            Grid.SetColumn(_label, 2);
        }
        else
        {
            grid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Auto),
                new ColumnDefinition(GridLength.Auto),
            };
            Grid.SetColumn(_label, 0);
            Grid.SetColumn(_divider, 1);
            Grid.SetColumn(_image, 2);
        }

        grid.Add(_image);
        grid.Add(_divider);
        grid.Add(_label);

        return grid;
    }

    private VerticalStackLayout BuildVerticalStack(ButtonImagePosition position)
    {
        var stack = new VerticalStackLayout
        {
            Spacing = 4,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        if (position == ButtonImagePosition.Top)
        {
            stack.Add(_image);
            stack.Add(_label);
        }
        else
        {
            stack.Add(_label);
            stack.Add(_image);
        }

        return stack;
    }
}
