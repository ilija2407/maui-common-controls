using Microsoft.Maui.Controls.Shapes;

namespace CommonControls.Maui.Controls;

public class BulletGraph : ContentView
{
    // ── Bindable Properties ──────────────────────────────────────────────────

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(BulletGraph), string.Empty,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty SubtitleProperty =
        BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(BulletGraph), string.Empty,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(double), typeof(BulletGraph), 0.0,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty ValueTextProperty =
        BindableProperty.Create(nameof(ValueText), typeof(string), typeof(BulletGraph), string.Empty,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty TargetProperty =
        BindableProperty.Create(nameof(Target), typeof(double), typeof(BulletGraph), double.NaN,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty MinimumProperty =
        BindableProperty.Create(nameof(Minimum), typeof(double), typeof(BulletGraph), 0.0,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty MaximumProperty =
        BindableProperty.Create(nameof(Maximum), typeof(double), typeof(BulletGraph), 100.0,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty BarHeightProperty =
        BindableProperty.Create(nameof(BarHeight), typeof(double), typeof(BulletGraph), 10.0,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(BulletGraph), 5.0,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty FillColorProperty =
        BindableProperty.Create(nameof(FillColor), typeof(Color), typeof(BulletGraph), Color.FromArgb("#7C3AED"),
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty TrackColorProperty =
        BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(BulletGraph), Color.FromArgb("#EDE7F6"),
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty TargetColorProperty =
        BindableProperty.Create(nameof(TargetColor), typeof(Color), typeof(BulletGraph), Color.FromArgb("#1F2937"),
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty ShowTargetMarkerProperty =
        BindableProperty.Create(nameof(ShowTargetMarker), typeof(bool), typeof(BulletGraph), true,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty ShowAxisLabelsProperty =
        BindableProperty.Create(nameof(ShowAxisLabels), typeof(bool), typeof(BulletGraph), false,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty PoorRangeEndProperty =
        BindableProperty.Create(nameof(PoorRangeEnd), typeof(double), typeof(BulletGraph), double.NaN,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty AverageRangeEndProperty =
        BindableProperty.Create(nameof(AverageRangeEnd), typeof(double), typeof(BulletGraph), double.NaN,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    public static readonly BindableProperty GoodRangeEndProperty =
        BindableProperty.Create(nameof(GoodRangeEnd), typeof(double), typeof(BulletGraph), double.NaN,
            propertyChanged: (b, _, _) => ((BulletGraph)b).Rebuild());

    // ── Public Properties ────────────────────────────────────────────────────

    public string Title          { get => (string)GetValue(TitleProperty);          set => SetValue(TitleProperty, value); }
    public string Subtitle       { get => (string)GetValue(SubtitleProperty);       set => SetValue(SubtitleProperty, value); }
    public double Value          { get => (double)GetValue(ValueProperty);          set => SetValue(ValueProperty, value); }
    public string ValueText      { get => (string)GetValue(ValueTextProperty);      set => SetValue(ValueTextProperty, value); }
    public double Target         { get => (double)GetValue(TargetProperty);         set => SetValue(TargetProperty, value); }
    public double Minimum        { get => (double)GetValue(MinimumProperty);        set => SetValue(MinimumProperty, value); }
    public double Maximum        { get => (double)GetValue(MaximumProperty);        set => SetValue(MaximumProperty, value); }
    public double BarHeight      { get => (double)GetValue(BarHeightProperty);      set => SetValue(BarHeightProperty, value); }
    public double CornerRadius   { get => (double)GetValue(CornerRadiusProperty);   set => SetValue(CornerRadiusProperty, value); }
    public Color  FillColor      { get => (Color)GetValue(FillColorProperty);       set => SetValue(FillColorProperty, value); }
    public Color  TrackColor     { get => (Color)GetValue(TrackColorProperty);      set => SetValue(TrackColorProperty, value); }
    public Color  TargetColor    { get => (Color)GetValue(TargetColorProperty);     set => SetValue(TargetColorProperty, value); }
    public bool   ShowTargetMarker { get => (bool)GetValue(ShowTargetMarkerProperty); set => SetValue(ShowTargetMarkerProperty, value); }
    public bool   ShowAxisLabels { get => (bool)GetValue(ShowAxisLabelsProperty);   set => SetValue(ShowAxisLabelsProperty, value); }
    public double PoorRangeEnd   { get => (double)GetValue(PoorRangeEndProperty);   set => SetValue(PoorRangeEndProperty, value); }
    public double AverageRangeEnd { get => (double)GetValue(AverageRangeEndProperty); set => SetValue(AverageRangeEndProperty, value); }
    public double GoodRangeEnd   { get => (double)GetValue(GoodRangeEndProperty);   set => SetValue(GoodRangeEndProperty, value); }

    // ── Constructor ──────────────────────────────────────────────────────────

    public BulletGraph()
    {
        Rebuild();
    }

    // ── Build UI ─────────────────────────────────────────────────────────────

    private void Rebuild()
    {
        var root = new VerticalStackLayout { Spacing = 6 };

        // Title row
        var titleRow = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            }
        };

        var titleLabel = new Label
        {
            Text = Title,
            FontSize = 13,
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromArgb("#1F2937"),
            VerticalOptions = LayoutOptions.Center
        };
        Grid.SetColumn(titleLabel, 0);
        titleRow.Children.Add(titleLabel);

        var valueLabel = new Label
        {
            Text = ValueText,
            FontSize = 13,
            FontAttributes = FontAttributes.Bold,
            TextColor = FillColor,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.End
        };
        Grid.SetColumn(valueLabel, 1);
        titleRow.Children.Add(valueLabel);

        root.Children.Add(titleRow);

        // Subtitle
        if (!string.IsNullOrEmpty(Subtitle))
        {
            root.Children.Add(new Label
            {
                Text = Subtitle,
                FontSize = 11,
                TextColor = Color.FromArgb("#6B7280")
            });
        }

        // Bar
        root.Children.Add(BuildBar());

        // Axis labels
        if (ShowAxisLabels)
        {
            root.Children.Add(BuildAxisLabels());
        }

        Content = root;
    }

    private View BuildBar()
    {
        var range = Maximum - Minimum;
        if (range <= 0) range = 1;

        var cr = CornerRadius;
        var barH = BarHeight;

        // Outer track
        var track = new Border
        {
            BackgroundColor = TrackColor,
            HeightRequest = barH,
            HorizontalOptions = LayoutOptions.Fill,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(cr) }
        };

        var trackGrid = new Grid { HeightRequest = barH };

        // Qualitative range bands (poor / average / good)
        bool hasBands = !double.IsNaN(PoorRangeEnd) || !double.IsNaN(AverageRangeEnd) || !double.IsNaN(GoodRangeEnd);
        if (hasBands)
        {
            var bandsGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = barH
            };

            double prevEnd = Minimum;
            (double end, Color color)[] bands =
            [
                (!double.IsNaN(PoorRangeEnd)    ? PoorRangeEnd    : Minimum, Color.FromArgb("#FCA5A5")),
                (!double.IsNaN(AverageRangeEnd) ? AverageRangeEnd : Minimum, Color.FromArgb("#FCD34D")),
                (!double.IsNaN(GoodRangeEnd)    ? GoodRangeEnd    : Maximum, Color.FromArgb("#6EE7B7")),
            ];

            foreach (var (end, color) in bands)
            {
                if (end <= prevEnd) continue;
                double fraction = (end - prevEnd) / range;
                bandsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(fraction, GridUnitType.Star) });
                prevEnd = end;
            }

            // fill remaining
            if (prevEnd < Maximum)
            {
                double fraction = (Maximum - prevEnd) / range;
                bandsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(fraction, GridUnitType.Star) });
            }

            prevEnd = Minimum;
            int col = 0;
            foreach (var (end, color) in bands)
            {
                if (end <= prevEnd) continue;
                var bandView = new BoxView
                {
                    BackgroundColor = color,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill
                };
                Grid.SetColumn(bandView, col);
                bandsGrid.Children.Add(bandView);
                prevEnd = end;
                col++;
            }

            trackGrid.Children.Add(bandsGrid);
        }
        else
        {
            track.Content = new BoxView { BackgroundColor = TrackColor };
        }

        // Value fill bar
        double valueFraction = Math.Clamp((Value - Minimum) / range, 0, 1);
        var fillContainer = new Grid
        {
            HorizontalOptions = LayoutOptions.Fill,
            HeightRequest = barH
        };

        var fillBorder = new Border
        {
            BackgroundColor = FillColor,
            HeightRequest = barH,
            HorizontalOptions = LayoutOptions.Fill,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(cr) },
            WidthRequest = -1
        };

        // Use a grid with star columns to represent the fill fraction
        var fillGrid = new Grid { HorizontalOptions = LayoutOptions.Fill, HeightRequest = barH };
        fillGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(valueFraction, GridUnitType.Star) });
        fillGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1 - valueFraction, GridUnitType.Star) });

        var fillBar = new Border
        {
            BackgroundColor = FillColor,
            HeightRequest = barH,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(cr) },
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill
        };
        Grid.SetColumn(fillBar, 0);
        fillGrid.Children.Add(fillBar);

        // Target marker
        if (ShowTargetMarker && !double.IsNaN(Target))
        {
            double targetFraction = Math.Clamp((Target - Minimum) / range, 0, 1);
            var markerGrid = new Grid { HorizontalOptions = LayoutOptions.Fill, HeightRequest = barH };
            markerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(targetFraction, GridUnitType.Star) });
            markerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Absolute) });
            markerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1 - targetFraction, GridUnitType.Star) });

            var marker = new BoxView
            {
                BackgroundColor = TargetColor,
                WidthRequest = 2,
                HeightRequest = barH + 4,
                VerticalOptions = LayoutOptions.Center
            };
            Grid.SetColumn(marker, 1);
            markerGrid.Children.Add(marker);

            var wrapper = new Grid { HorizontalOptions = LayoutOptions.Fill, HeightRequest = barH };
            wrapper.Children.Add(hasBands ? trackGrid : track);
            wrapper.Children.Add(fillGrid);
            wrapper.Children.Add(markerGrid);
            return wrapper;
        }

        var barWrapper = new Grid { HorizontalOptions = LayoutOptions.Fill, HeightRequest = barH };
        barWrapper.Children.Add(hasBands ? (View)trackGrid : track);
        barWrapper.Children.Add(fillGrid);
        return barWrapper;
    }

    private View BuildAxisLabels()
    {
        var range = Maximum - Minimum;
        if (range <= 0) range = 1;

        var grid = new Grid { HorizontalOptions = LayoutOptions.Fill };
        int steps = 5;
        for (int i = 0; i <= steps; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        for (int i = 0; i <= steps; i++)
        {
            double val = Minimum + (range / steps) * i;
            var lbl = new Label
            {
                Text = val % 1 == 0 ? ((int)val).ToString() : val.ToString("0.#"),
                FontSize = 10,
                TextColor = Color.FromArgb("#9CA3AF"),
                HorizontalOptions = i == 0 ? LayoutOptions.Start : i == steps ? LayoutOptions.End : LayoutOptions.Center
            };
            Grid.SetColumn(lbl, i);
            grid.Children.Add(lbl);
        }

        return grid;
    }
}
