using System.Windows.Input;

namespace CommonControls.Maui.Controls;

public interface IStateButton
{
    bool IsBusy { get; }
    string Text { get; }
    Color TextColor { get; }
    ImageSource? ImageSource { get; }
    ButtonImagePosition ImagePosition { get; }
    ICommand? Command { get; }
    object? CommandParameter { get; }
    ButtonAnimationType AnimationType { get; }
    double CornerRadius { get; }
    Color BorderColor { get; }
    bool ShowDivider { get; }
    Color DividerColor { get; }
}
