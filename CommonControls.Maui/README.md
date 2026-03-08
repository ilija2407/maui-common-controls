# CommonControls.Maui

[![NuGet](https://img.shields.io/nuget/v/CommonControls.Maui.svg)](https://www.nuget.org/packages/CommonControls.Maui/)

A .NET MAUI library providing clean, customisable controls for Android, iOS, Mac Catalyst, and Windows.

## Controls

| Control | Description |
|---|---|
| **BorderlessEntry** | Entry without platform border/underline |
| **BorderlessEditor** | Editor without platform border/underline |
| **PasswordEntry** | Password input with built-in show/hide toggle |
| **ValidationEntry** | Entry with configurable border, separator, and inline error message |
| **StateButton** | Tappable button with press animations, busy/loading state, divider layout, gradient background, and image support |

### Platform support

| Control | Android | iOS | Mac Catalyst | Windows |
|---|---|---|---|---|
| **BorderlessEntry** | ✅ | ✅ | ✅ | ✅ |
| **BorderlessEditor** | ✅ | ✅ | ✅ | ✅ |
| **PasswordEntry** | ✅ | ✅ | ✅ | ✅ |
| **ValidationEntry** | ✅ | ✅ | ✅ | ✅ |
| **StateButton** | ✅ | ✅ | ✅ | ✅ |

---

## Installation

```xml
<ItemGroup>
  <PackageReference Include="CommonControls.Maui" Version="1.1.1" />
</ItemGroup>
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

An entry with a configurable border and inline error message. The border and separator are independently controlled — mix and match to suit your design.

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
    Placeholder="Password"
    BorderColor="Black"
    BorderVisible="True"
    CornerRadius="8"
    ErrorBorderColor="Black"
    SeparatorVisible="True"
    ErrorSeparatorColor="Black"
    ErrorMessage="Must be at least 8 characters"
    ErrorColor="Orange"
    ErrorFontSize="11"
    IsValid="{Binding IsPasswordValid}" />
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

A fully customisable tappable button built as a `ContentView`. Supports press animations, a busy/loading spinner, an optional vertical divider with a trailing icon, gradient backgrounds, and a visual disabled state.

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

> **iOS & Mac Catalyst note:** reference rasterised images with `.png` extension (e.g. `icon_lock.png`), not `.svg`.
> Alternatively use `FontImageSource` to avoid the bundle lookup entirely:
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
    await DoWorkAsync();
    SaveBtn.IsBusy = false;
});
```

### Command binding

```xml
<cc:StateButton
    Text="Submit"
    Command="{Binding SubmitCommand}"
    CommandParameter="{Binding Item}" />
```

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
| **Command** | ICommand | null | Executed after the press animation completes |
| **CommandParameter** | object | null | Parameter passed to `Command` |
