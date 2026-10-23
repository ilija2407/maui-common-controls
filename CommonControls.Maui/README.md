# CommonControls.Maui

[![NuGet](https://img.shields.io/nuget/v/CommonControls.Maui.svg)](https://www.nuget.org/packages/CommonControls.Maui/)

Reusable .NET MAUI controls for everyday UI needs, from borderless inputs and inline validation feedback to animated buttons and compact KPI displays. Use the controls in existing XAML layouts with MAUI bindings and commands.

This is the control reference for the repository source. For screenshots, recordings, and a complete first-use example, see the [project overview](https://github.com/ilija2407/maui-common-controls#readme). Check the README included with your installed NuGet version for its available API.

## Controls

| Control | Description |
|---|---|
| **BorderlessEntry** | Entry without platform border/underline |
| **BorderlessEditor** | Editor without platform border/underline |
| **PasswordEntry** | Password input with built-in show/hide toggle |
| **ValidationEntry** | Entry with configurable border, separator, and inline error message |
| **StateButton** | Tappable button with press animations, busy/loading state, divider layout, gradient background, and image support |
| **BulletGraph** | Compact value bar with target marker, qualitative ranges, title, subtitle, value text, and optional axis labels |

### Compatibility

| Control | Android | iOS | Mac Catalyst | Windows |
|---|---|---|---|---|
| **BorderlessEntry** | ✅ | ✅ | ✅ | ✅ |
| **BorderlessEditor** | ✅ | ✅ | ✅ | ✅ |
| **PasswordEntry** | ✅ | ✅ | ✅ | ✅ |
| **ValidationEntry** | ✅ | ✅ | ✅ | ✅ |
| **StateButton** | ✅ | ✅ | ✅ | ✅ |
| **BulletGraph** | ✅ | ✅ | ✅ | ✅ |

The current library project targets .NET 9 and .NET 10 for all four platforms. The table reflects the declared platform targets, rather than a device-by-device test matrix. Windows targets build 19041 or later. The sample application targets .NET 10; Apple builds require a Mac with compatible Xcode tooling.

---

## Installation

Run in your .NET MAUI application directory:

```shell
dotnet add package CommonControls.Maui
```

## Setup

Register handler mappings once in **MauiProgram.cs**:

```csharp
using CommonControls.Maui.Hosting;

builder.UseCommonControls();
```

## XAML namespace

```xml
xmlns:cc="clr-namespace:CommonControls.Maui.Controls;assembly=CommonControls.Maui"
```

---

## BorderlessEntry

Entry with the platform-native border/underline removed.

```xml
<cc:BorderlessEntry Placeholder="Email" />
```

---

## BorderlessEditor

Editor with the platform-native border removed.

```xml
<cc:BorderlessEditor Placeholder="Notes" HeightRequest="100" />
```

---

## PasswordEntry

Password input with a built-in show/hide toggle button. Uses bundled eye icons by default; supports custom image sources.

```xml
<!-- Default icons -->
<cc:PasswordEntry Placeholder="Password" />

<!-- Custom icons -->
<cc:PasswordEntry
    Placeholder="Password"
    ShowPasswordImageSource="my_eye.png"
    HidePasswordImageSource="my_hidden.png"
    ImageHeight="20"
    ImageWidth="20" />
```

### Properties

| Property | Type | Default | Description |
|---|---|---|---|
| **Text** | string | null | Input text (two-way bindable) |
| **Placeholder** | string | null | Placeholder text |
| **IsPassword** | bool | true | Toggles password masking |
| **ShowPasswordImageSource** | ImageSource | built-in eye icon | Icon shown when password is hidden |
| **HidePasswordImageSource** | ImageSource | built-in hidden icon | Icon shown when password is visible |
| **ImageHeight** | double | 24 | Toggle icon height |
| **ImageWidth** | double | 24 | Toggle icon width |
| **FontSize** | double | 14 | Input font size |
| **TextColor** | Color | platform default | Input text color |
| **PlaceholderColor** | Color | platform default | Placeholder text color |

---

## ValidationEntry

An entry that displays validation feedback with a configurable border and inline error message. The border and separator are independently controlled. Supply `IsValid` and `ErrorMessage` from your application or view model; the control does not evaluate validation rules itself.

### Border / separator combinations

| BorderVisible | SeparatorVisible | Error state appearance |
|---|---|---|
| false | false | no border, no separator — only error text |
| true | false | border switches to ErrorBorderColor, no separator |
| false | true | no border, separator line appears above error text |
| true | true | border and separator both switch to error color |

```xml
<!-- No border, separator only -->
<cc:ValidationEntry
    Placeholder="Email"
    Keyboard="Email"
    SeparatorVisible="True"
    ErrorSeparatorColor="Red"
    ErrorMessage="Please enter a valid email"
    IsValid="{Binding IsEmailValid}" />

<!-- Border only -->
<cc:ValidationEntry
    Placeholder="Username"
    BorderColor="Gray"
    BorderVisible="True"
    ErrorBorderColor="Red"
    ErrorMessage="This field is required"
    IsValid="{Binding IsUsernameValid}" />

<!-- Border and separator with corner radius -->
<cc:ValidationEntry
    Placeholder="Username"
    BorderColor="Black"
    BorderVisible="True"
    CornerRadius="8"
    ErrorBorderColor="Black"
    SeparatorVisible="True"
    ErrorSeparatorColor="Black"
    ErrorMessage="Username must be at least 8 characters"
    ErrorColor="Orange"
    ErrorFontSize="11"
    IsValid="{Binding IsUsernameValid}" />
```

### Properties

| Property | Type | Default | Description |
|---|---|---|---|
| **Text** | string | null | Input text (two-way bindable) |
| **Placeholder** | string | null | Placeholder text |
| **IsValid** | bool | true | When false, switches to error state |
| **ErrorMessage** | string | empty | Text shown below the entry when invalid |
| **Keyboard** | Keyboard | Default | Keyboard type (Email, Numeric, Telephone, etc.) |
| **FontSize** | double | 14 | Input font size |
| **TextColor** | Color | platform default | Input text color |
| **PlaceholderColor** | Color | platform default | Placeholder text color |
| **BorderVisible** | bool | false | Show a rectangular border around the control |
| **BorderColor** | Color | Transparent | Border color when valid |
| **ErrorBorderColor** | Color | Red | Border color when invalid |
| **CornerRadius** | double | 0 | Corner radius of the border |
| **SeparatorVisible** | bool | false | Show a 1px line above the error message when invalid |
| **ErrorSeparatorColor** | Color | Red | Separator color when invalid |
| **ErrorColor** | Color | Red | Error message text color |
| **ErrorFontSize** | double | 12 | Error message font size |

### Events

| Event | Description |
|---|---|
| **TextChanged** | Raised when the input text changes |

---

## StateButton

A customizable tappable button built as a `ContentView`. Supports press animations, a busy/loading spinner, an optional vertical divider in horizontal icon layouts, gradient backgrounds, and a visual disabled state.

### Basic usage

```xml
<!-- Solid filled -->
<cc:StateButton
    BackgroundColor="#512BD4"
    CornerRadius="10"
    Text="Tap me"
    TextColor="White" />

<!-- Outlined -->
<cc:StateButton
    BackgroundColor="Transparent"
    BorderColor="#512BD4"
    CornerRadius="10"
    Text="Tap me"
    TextColor="#512BD4" />
```

### Gradient background

```xml
<cc:StateButton CornerRadius="22" Text="Login" TextColor="#3B82F6">
    <cc:StateButton.BackgroundBrush>
        <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
            <GradientStop Offset="0.0" Color="#EFF6FF" />
            <GradientStop Offset="1.0" Color="#FFFEF5" />
        </LinearGradientBrush>
    </cc:StateButton.BackgroundBrush>
</cc:StateButton>
```

### Divider + trailing icon

Add `icon_lock.svg` or `icon_lock.png` to your application's `Resources/Images` as a `MauiImage` before using this example. The sample application includes the icon.

```xml
<cc:StateButton
    CornerRadius="22"
    HorizontalOptions="Fill"
    DividerColor="#3B82F6"
    ImagePosition="End"
    ImageSource="icon_lock.png"
    ShowDivider="True"
    Text="Login"
    TextColor="#3B82F6" />
```

> Add your icon to the application's `Resources/Images` as a `MauiImage`. Reference SVG assets using their generated `.png` filename (for example, `icon_lock.png`). The sample application includes this icon. Alternatively, use `FontImageSource` with a font and glyph available in your application:
> ```xml
> <cc:StateButton.ImageSource>
>     <FontImageSource Glyph="&#x1F512;" Size="18" Color="#3B82F6" />
> </cc:StateButton.ImageSource>
> ```

### Busy / loading state

```xml
<cc:StateButton x:Name="SaveBtn" Text="Save" BackgroundColor="#512BD4" TextColor="White" />
```
```csharp
SaveBtn.Command = new Command(async () =>
{
    SaveBtn.IsBusy = true;
    try
    {
        await DoWorkAsync(); // Replace with your application operation.
    }
    finally
    {
        SaveBtn.IsBusy = false;
    }
});
```

`IsBusy` blocks taps and preserves the button content's measured space while the loading indicator is shown. The application controls this state; commands do not set it automatically. In an MVVM application, bind `IsBusy` to a view model property.

### Command binding

```xml
<cc:StateButton
    Text="Submit"
    Command="{Binding SubmitCommand}"
    CommandParameter="{Binding Item}" />
```

Taps execute the command only when `CanExecute` returns true. To update the disabled appearance, bind `IsEnabled` to your application state as well; `StateButton` does not subscribe to `CanExecuteChanged`.

### Properties

| Property | Type | Default | Description |
|---|---|---|---|
| **Text** | string | "" | Button label |
| **TextColor** | Color | White | Label colour |
| **FontAttributes** | FontAttributes | None | Bold / Italic |
| **FontSize** | double | 14 | Label font size |
| **BackgroundColor** | Color | Transparent | Solid fill colour (overridden by `BackgroundBrush`) |
| **BackgroundBrush** | Brush | null | Gradient or solid brush painted on the button border |
| **BorderColor** | Color | Transparent | Stroke colour |
| **CornerRadius** | double | 8 | Corner radius |
| **ImageSource** | ImageSource | null | Trailing / leading icon |
| **ImagePosition** | ButtonImagePosition | Start | `Start`, `End`, `Top`, `Bottom` |
| **ShowDivider** | bool | false | Show a vertical divider between label and icon |
| **DividerColor** | Color | White | Divider colour |
| **AnimationType** | ButtonAnimationType | Scale | `Scale`, `Fade`, `None` |
| **IsBusy** | bool | false | Shows an `ActivityIndicator` and hides content while true |
| **IsEnabled** | bool | true | When false, blocks input and fades the button to 40 % opacity |
| **Command** | ICommand | null | Executed on tap when enabled, not busy, and CanExecute returns true; scale/fade feedback returns to its resting state afterward |
| **CommandParameter** | object | null | Parameter passed to `Command` |

---

## BulletGraph

A compact KPI visualization built from MAUI views. Display a value against a minimum/maximum range, add an optional target marker, and use qualitative bands to provide performance context.

Use the same `cc` namespace as the other controls; no additional package or registration is required for this implementation.

```xml
<cc:BulletGraph
    Title="Monthly revenue"
    Subtitle="Progress toward this month's target"
    Minimum="0"
    Maximum="100"
    Value="72"
    ValueText="72%"
    Target="85"
    PoorRangeEnd="40"
    AverageRangeEnd="70"
    GoodRangeEnd="100"
    ShowAxisLabels="True"
    FillColor="#512BD4" />
```

Bind `Value`, `ValueText`, and `Target` to view model properties for live data. `ValueText` is supplied separately from the numeric value, so your application controls units and formatting.

### Properties

| Property | Type | Default | Description |
| --- | --- | --- | --- |
| **Title** | string | empty | Header text |
| **Subtitle** | string | empty | Supporting text below the header |
| **Value** | double | 0 | Value represented by the fill bar |
| **ValueText** | string | empty | Formatted text displayed beside the title |
| **Minimum** | double | 0 | Start of the scale |
| **Maximum** | double | 100 | End of the scale |
| **Target** | double | NaN | Target position; NaN omits the marker |
| **ShowTargetMarker** | bool | true | Whether to display a configured target |
| **ShowAxisLabels** | bool | false | Whether to display scale labels |
| **PoorRangeEnd** | double | NaN | Upper boundary of the first qualitative band |
| **AverageRangeEnd** | double | NaN | Upper boundary of the second qualitative band |
| **GoodRangeEnd** | double | NaN | Upper boundary of the third qualitative band |
| **BarHeight** | double | 10 | Height of the bar in device-independent units |
| **CornerRadius** | double | 5 | Radius of the track and value bar corners |
| **FillColor** | Color | #7C3AED | Value bar and value text color |
| **TrackColor** | Color | #EDE7F6 | Background color when qualitative bands are not configured |
| **TargetColor** | Color | #1F2937 | Target marker color |

Set `Maximum` greater than `Minimum`, and provide range boundaries in ascending order within the scale. Value and target positions are clamped to the scale. Qualitative band colors are fixed in this implementation; fill, track, and target colors are configurable.

See the [bullet graph sample](https://github.com/ilija2407/maui-common-controls/blob/main/CommonControlsSample/BulletGraphSamplePage.xaml) for dashboard layouts.

---

## Contributing and license

See the [contribution guide](https://github.com/ilija2407/maui-common-controls/blob/main/CONTRIBUTING.md) for bug reports, control proposals, and pull requests. CommonControls.Maui is licensed under the [MIT License](https://github.com/ilija2407/maui-common-controls/blob/main/LICENSE).
