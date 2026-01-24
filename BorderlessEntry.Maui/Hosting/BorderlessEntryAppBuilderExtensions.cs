using BorderlessEntry.Maui.Controls;
using Microsoft.Maui.Handlers;

#if IOS
using UIKit;
#endif

namespace BorderlessEntry.Maui.Hosting;

public static class BorderlessEntryAppBuilderExtensions
{
    private static bool _initialized;

    public static MauiAppBuilder UseBorderlessEntry(this MauiAppBuilder builder)
    {
        if (_initialized)
        {
            return builder;
        }

        _initialized = true;

        EntryHandler.Mapper.AppendToMapping("BorderlessEntry.Maui", (handler, view) =>
        {
            if (view is not BorderlessEntry.Maui.Controls.BorderlessEntry)
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

        return builder;
    }
}
