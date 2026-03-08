using CommonControls.Maui.Controls;
using Microsoft.Maui.Handlers;

#if IOS || MACCATALYST
using UIKit;
#endif

namespace CommonControls.Maui.Hosting;

public static class CommonControlsAppBuilderExtensions
{
    private static bool _initialized;

    public static MauiAppBuilder UseCommonControls(this MauiAppBuilder builder)
    {
        if (_initialized)
        {
            return builder;
        }

        _initialized = true;

        // BorderlessEntry handler mapping
        EntryHandler.Mapper.AppendToMapping("CommonControls.Maui.BorderlessEntry", (handler, view) =>
        {
            if (view is not CommonControls.Maui.Controls.BorderlessEntry)
            {
                return;
            }

#if ANDROID
            var platformView = handler.PlatformView as global::Android.Widget.EditText;
            if (platformView is null)
            {
                return;
            }

            platformView.Background = null;
            platformView.SetPadding(0, 0, 0, 0);
#elif IOS || MACCATALYST
            var platformView = handler.PlatformView;
            if (platformView is null)
            {
                return;
            }

            platformView.BorderStyle = UITextBorderStyle.None;
            platformView.BackgroundColor = UIColor.Clear;
#elif WINDOWS
            var platformView = handler.PlatformView;
            if (platformView is null)
            {
                return;
            }

            platformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            platformView.Padding = new Microsoft.UI.Xaml.Thickness(0);
            platformView.Resources["TextControlBorderThemeThickness"] = new Microsoft.UI.Xaml.Thickness(0);
            platformView.Resources["TextControlBorderThemeThicknessFocused"] = new Microsoft.UI.Xaml.Thickness(0);
#endif
        });

        // BorderlessEditor handler mapping
        EditorHandler.Mapper.AppendToMapping("CommonControls.Maui.BorderlessEditor", (handler, view) =>
        {
            if (view is not CommonControls.Maui.Controls.BorderlessEditor)
            {
                return;
            }

#if ANDROID
            var platformView = handler.PlatformView as global::Android.Widget.EditText;
            if (platformView is null)
            {
                return;
            }

            platformView.Background = null;
            platformView.SetPadding(0, 0, 0, 0);
#elif IOS || MACCATALYST
            var platformView = handler.PlatformView;
            if (platformView is null)
            {
                return;
            }

            platformView.Layer.BorderWidth = 0;
            platformView.BackgroundColor = UIColor.Clear;
#elif WINDOWS
            var platformView = handler.PlatformView;
            if (platformView is null)
            {
                return;
            }

            platformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            platformView.Padding = new Microsoft.UI.Xaml.Thickness(0);
            platformView.Resources["TextControlBorderThemeThickness"] = new Microsoft.UI.Xaml.Thickness(0);
            platformView.Resources["TextControlBorderThemeThicknessFocused"] = new Microsoft.UI.Xaml.Thickness(0);
#endif
        });

        return builder;
    }
}
