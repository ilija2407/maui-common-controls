namespace CommonControls.Maui.Controls;

// iOS-specific customisation point for StateButton.
// UILongPressGestureRecognizer was removed: on iOS it blocks TapGestureRecognizer from
// firing (the long-press reaches Began and holds the gesture system, preventing Tapped).
// Animation and tap handling are managed by shared MAUI gesture recognizers.
// Add platform-specific handler mappings here when needed.
public partial class StateButton { }
