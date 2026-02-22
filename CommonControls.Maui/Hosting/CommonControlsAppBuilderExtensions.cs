using CommonControls.Maui.Controls;
using Microsoft.Maui.Handlers;

#if IOS
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
#elif IOS
            var platformView = handler.PlatformView;
            if (platformView is null)
            {
                return;
            }

            platformView.BorderStyle = UITextBorderStyle.None;
            platformView.BackgroundColor = UIColor.Clear;
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
#endif
        });

        return builder;
    }
}
