# CommonControls.Maui

[![NuGet version](https://img.shields.io/nuget/v/CommonControls.Maui.svg)](https://www.nuget.org/packages/CommonControls.Maui/)
[![NuGet downloads](https://img.shields.io/nuget/dt/CommonControls.Maui.svg)](https://www.nuget.org/packages/CommonControls.Maui/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

**Reusable .NET MAUI controls for everyday UI needs.**

CommonControls.Maui brings common input, button, and KPI display patterns into customizable controls. Build forms with borderless inputs, password visibility toggles, and inline validation feedback; add buttons with animations and loading states; and display progress against a target with compact bullet graphs.

The controls use MAUI views, bindable properties, and commands, so you can use them in existing XAML layouts and MVVM workflows. The library targets Android, iOS, Mac Catalyst, and Windows.

[Quick start](#quick-start) · [Controls](#controls) · [Demos](#demos) · [Control reference](CommonControls.Maui/README.md) · [Contributing](CONTRIBUTING.md)

![CommonControls.Maui control showcase](https://github.com/user-attachments/assets/58543b21-e0ae-4bc6-b05a-af54bc531a26)

## Controls

| Control | Use it for | Features |
| --- | --- | --- |
| [BorderlessEntry](CommonControls.Maui/README.md#borderlessentry) | Single-line text input with your own styling | Native border and underline removal; standard MAUI `Entry` properties and bindings |
| [BorderlessEditor](CommonControls.Maui/README.md#borderlesseditor) | Notes, comments, and other multiline input | Native border removal; standard MAUI `Editor` properties and bindings |
| [PasswordEntry](CommonControls.Maui/README.md#passwordentry) | Password input with a visibility toggle | Bundled show/hide icons, custom image sources, and two-way text binding |
| [ValidationEntry](CommonControls.Maui/README.md#validationentry) | Showing field validation results | Inline error messages, optional borders and separators, and configurable error colors |
| [StateButton](CommonControls.Maui/README.md#statebutton) | Actions that need interaction feedback | Scale/fade animations, loading indicator, disabled appearance, gradients, icons, dividers, and command binding |
| [BulletGraph](CommonControls.Maui/README.md#bulletgraph) | Compact progress and KPI displays | Value bar, target marker, qualitative ranges, titles, value text, and optional axis labels |

This table describes the controls in the repository source. Check the documentation included with your installed NuGet version for its available API.

## Quick start

### 1. Install the package

Run this command in your .NET MAUI application directory:

```shell
dotnet add package CommonControls.Maui
```

### 2. Register the controls

In `MauiProgram.cs`, add the namespace and call `UseCommonControls()` on your existing builder. This registers the platform mappings used by the borderless inputs, including those inside `PasswordEntry` and `ValidationEntry`.

```csharp
using CommonControls.Maui.Hosting;

// Add this after creating your application's MauiAppBuilder.
builder.UseCommonControls();
```

### 3. Use a control in XAML

This page demonstrates borderless input, a password visibility toggle, an inline error state, and an animated button. Set the namespace and class name to match your application.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:cc="clr-namespace:CommonControls.Maui.Controls;assembly=CommonControls.Maui"
    x:Class="MyApp.MainPage">

    <VerticalStackLayout Padding="24" Spacing="16">
        <cc:BorderlessEntry
            Keyboard="Email"
            Placeholder="Email address" />

        <cc:PasswordEntry Placeholder="Password" />

        <cc:ValidationEntry
            BorderVisible="True"
            CornerRadius="8"
            ErrorMessage="Please enter a username."
            IsValid="False"
            Placeholder="Username" />

        <cc:StateButton
            AnimationType="Scale"
            BackgroundColor="#512BD4"
            CornerRadius="10"
            Text="Create account"
            TextColor="White" />
    </VerticalStackLayout>
</ContentPage>
```

For an application action, bind `StateButton.Command` and `IsBusy` to your view model:

```xml
<cc:StateButton
    BackgroundColor="#512BD4"
    Command="{Binding SaveCommand}"
    IsBusy="{Binding IsSaving}"
    Text="Save changes"
    TextColor="White" />
```

Your view model supplies `SaveCommand` and `IsSaving`. While `IsBusy` is true, the button shows a loading indicator and ignores taps.

`ValidationEntry` displays validation results supplied through `IsValid` and `ErrorMessage`. Define the validation rules in your application or view model.

See the [control reference](CommonControls.Maui/README.md) for gradients, icon layouts, validation styling, and bullet graph examples.

## Demos

These recordings show the controls in action. Expand a recording to view it on GitHub, or follow its video link in other Markdown viewers.

<details>
<summary>Mac Catalyst demonstration</summary>

https://github.com/user-attachments/assets/94c712d3-987b-474a-b9f1-ba88c2566db2

</details>

<details>
<summary>Control demonstration</summary>

https://github.com/user-attachments/assets/afb4c94c-6141-4614-9c34-1807e8ec9d6b

</details>

<details>
<summary>StateButton overview</summary>

https://github.com/user-attachments/assets/385ea295-e291-4f53-b69f-36926bc517f5

</details>

<details>
<summary>StateButton icon positions and divider layouts</summary>

https://github.com/user-attachments/assets/2fa76260-6179-4afb-9271-f0b0dc6e4604

</details>

<details>
<summary>Earlier input control showcase</summary>

![Earlier borderless input and password toggle examples](https://github.com/user-attachments/assets/93dddf7b-f9e2-4a89-9754-c02a954ad175)

This image includes earlier BorderlessEntry.Maui branding. Use the `CommonControls.Maui` package and namespaces shown above for the current library.

</details>

## Compatibility

| Platform | Library target frameworks |
| --- | --- |
| Android | `net9.0-android`, `net10.0-android` |
| iOS | `net9.0-ios`, `net10.0-ios` |
| Mac Catalyst | `net9.0-maccatalyst`, `net10.0-maccatalyst` |
| Windows | `net9.0-windows10.0.19041.0`, `net10.0-windows10.0.19041.0` |

These are the targets declared by the current library project; the sample application targets .NET 10. Build and run each platform with its corresponding MAUI SDK, workload, and platform tools. iOS and Mac Catalyst builds require a Mac with a compatible Xcode installation. Windows targets Windows 10 version 2004 (build 19041) or later.

### Integration notes

- **Input behavior:** `BorderlessEntry` and `BorderlessEditor` inherit from MAUI's native input controls. `PasswordEntry` and `ValidationEntry` are composed controls with the properties documented in the reference.
- **Images:** For SVG assets included as `MauiImage`, use the generated `.png` filename in `ImageSource`, for example `icon_lock.png`. The sample application includes icon assets.
- **Button commands:** Taps check `Command.CanExecute`. Bind `IsEnabled` explicitly when the button's disabled appearance should track application state; the control does not subscribe to `CanExecuteChanged`.
- **Styling and interaction:** Test your chosen colors, focus behavior, keyboard interaction, and accessibility in the platforms your application ships to.

## Sample application

Explore [CommonControlsSample](CommonControlsSample) for input styling, button configurations, and bullet graph examples.

1. Clone the repository and open `CommonControlsSample.slnx` in an IDE that supports .NET 10 and .NET MAUI.
2. Install the MAUI workloads and platform tools required for your chosen target.
3. Select `CommonControlsSample` as the startup project and run it on your target device or emulator.

The sample references the library project directly, so it demonstrates the source in your checkout.

## Contributing

Bug reports, documentation improvements, and control proposals are welcome. Read [CONTRIBUTING.md](CONTRIBUTING.md) for the development workflow and what to include in an issue or pull request.

## License

CommonControls.Maui is licensed under the [MIT License](LICENSE).
