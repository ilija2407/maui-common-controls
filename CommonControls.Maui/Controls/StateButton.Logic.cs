using Microsoft.Maui.Controls.Shapes;

namespace CommonControls.Maui.Controls;

public partial class StateButton
{
    private const string AnimationKey = "StateButtonAnim";

    // async void is intentional: OnTapped is an event handler and the animation sequence
    // must be awaited end-to-end so ScaleTo(1.0) is guaranteed to run after ScaleTo(0.95).
    private async void OnTapped(object? sender, TappedEventArgs e)
    {
        if (IsBusy || !IsEnabled) return;

        switch (AnimationType)
        {
            case ButtonAnimationType.Scale:
                this.AbortAnimation(AnimationKey);
                await this.ScaleTo(0.95, 60);
                ExecuteCommand();
                await this.ScaleTo(1.0, 100);
                break;
            case ButtonAnimationType.Fade:
                this.AbortAnimation(AnimationKey);
                await this.FadeTo(0.7, 60);
                ExecuteCommand();
                await this.FadeTo(1.0, 100);
                break;
            default:
                ExecuteCommand();
                break;
        }
    }

    // Called by PointerGestureRecognizer.PointerPressed – gives immediate visual feedback
    // while the finger is held down before a tap is recognised.
    private void PlayTouchDown()
    {
        if (IsBusy || !IsEnabled) return;
        this.AbortAnimation(AnimationKey);
        if (AnimationType == ButtonAnimationType.Scale)
            new Animation(v => Scale = v, Scale, 0.95).Commit(this, AnimationKey, length: 100);
        else if (AnimationType == ButtonAnimationType.Fade)
            new Animation(v => Opacity = v, Opacity, 0.7).Commit(this, AnimationKey, length: 100);
    }

    // Called by PointerGestureRecognizer.PointerReleased / PointerExited – resets visual state
    // for non-tap interactions (e.g. long-press then release, or finger slides off the button).
    private void PlayTouchUp()
    {
        this.AbortAnimation(AnimationKey);
        if (AnimationType == ButtonAnimationType.Scale)
            new Animation(v => Scale = v, Scale, 1.0).Commit(this, AnimationKey, length: 100);
        else if (AnimationType == ButtonAnimationType.Fade)
            new Animation(v => Opacity = v, Opacity, 1.0).Commit(this, AnimationKey, length: 100);
    }

    private void ExecuteCommand()
    {
        var command = Command;
        var parameter = CommandParameter;
        if (command?.CanExecute(parameter) == true)
            command.Execute(parameter);
    }

    private static void OnButtonBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn && btn.BackgroundBrush is null)
            btn._border.BackgroundColor = (Color)newValue;
    }

    private static void OnIsBusyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not StateButton btn) return;
        var busy = (bool)newValue;
        // Use Opacity instead of IsVisible so the content stack stays in layout measurement.
        // IsVisible=false would remove it from the Grid, shrinking the button to the
        // ActivityIndicator size and causing an unwanted resize on every IsBusy toggle.
        btn._contentStack.Opacity = busy ? 0 : 1;
        btn._contentStack.InputTransparent = busy;
        btn._activityIndicator.IsVisible = busy;
        btn._activityIndicator.IsRunning = busy;
    }

    private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
            btn._label.Text = (string)newValue;
    }

    private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
            btn._label.TextColor = (Color)newValue;
    }

    private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not StateButton btn) return;
        var src = newValue as ImageSource;
        btn._image.Source = src;
        btn._image.IsVisible = src is not null;
        btn._divider.IsVisible = btn.ShowDivider && src is not null;
    }

    private static void OnShowDividerChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
            btn._divider.IsVisible = (bool)newValue && btn._image.IsVisible;
    }

    private static void OnDividerColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
            btn._divider.Color = (Color)newValue;
    }

    private static void OnImagePositionChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not StateButton btn) return;
        btn._contentStack = btn.BuildContentStack((ButtonImagePosition)newValue);
        btn._rootGrid.Clear();
        btn._rootGrid.Add(btn._contentStack);
        btn._rootGrid.Add(btn._activityIndicator);
    }

    private static void OnCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not StateButton btn) return;
        if (btn._border.StrokeShape is RoundRectangle rr)
            rr.CornerRadius = new CornerRadius((double)newValue);
    }

    private static void OnBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
            btn._border.Stroke = new SolidColorBrush((Color)newValue);
    }

    private static void OnBackgroundBrushChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
        {
            if (newValue is Brush brush)
                btn._border.Background = brush;
            else
                btn._border.BackgroundColor = btn.BackgroundColor;
        }
    }

    private static void OnFontAttributesChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
            btn._label.FontAttributes = (FontAttributes)newValue;
    }

    private static void OnFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StateButton btn)
            btn._label.FontSize = (double)newValue;
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(IsEnabled))
            _border.Opacity = IsEnabled ? 1.0 : 0.4;
    }
}
