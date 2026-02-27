# CommonControls.Maui

A .NET MAUI library providing clean, borderless input controls with full Android and iOS handler mappings.

## Controls

| Control | Description |
|---|---|
| `BorderlessEntry` | `Entry` without platform border/underline |
| `BorderlessEditor` | `Editor` without platform border/underline |
| `PasswordEntry` | Password input with built-in show/hide toggle |
| `ValidationEntry` | Entry with configurable border, separator line, and inline error message |

---

## Installation

```xml
<ItemGroup>
  <PackageReference Include="CommonControls.Maui" Version="1.0.5" />
</ItemGroup>
```

## Setup

Register handler mappings once in `MauiProgram.cs`:

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

`Entry` with the platform-native border/underline removed.

```xml
<cc:BorderlessEntry Placeholder="Email" />
```

---

## BorderlessEditor

`Editor` with the platform-native border removed.

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
| `Text` | `string` | `null` | Input text (two-way bindable) |
| `Placeholder` | `string` | `null` | Placeholder text |
| `IsPassword` | `bool` | `true` | Toggles password masking |
| `ShowPasswordImageSource` | `ImageSource` | built-in eye icon | Icon shown when password is hidden |
| `HidePasswordImageSource` | `ImageSource` | built-in hidden icon | Icon shown when password is visible |
| `ImageHeight` | `double` | `24` | Toggle icon height |
| `ImageWidth` | `double` | `24` | Toggle icon width |
| `FontSize` | `double` | `14` | Input font size |
| `TextColor` | `Color` | platform default | Input text color |
| `PlaceholderColor` | `Color` | platform default | Placeholder text color |

---

## ValidationEntry

An entry that wraps a configurable border and displays an inline error message. The border and separator line are independently controlled.

### Border / separator combinations

| `BorderVisible` | `SeparatorVisible` | Error state appearance |
|---|---|---|
| `false` | `false` | no border, no separator — only error text |
| `true` | `false` | border changes to `ErrorBorderColor`, no separator |
| `false` | `true` | no border, separator line appears above error text |
| `true` | `true` | border + separator line, both switch to error color |

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
| `Text` | `string` | `null` | Input text (two-way bindable) |
| `Placeholder` | `string` | `null` | Placeholder text |
| `IsValid` | `bool` | `true` | When `false`, switches to error state |
| `ErrorMessage` | `string` | `""` | Text shown below the entry when invalid |
| `Keyboard` | `Keyboard` | `Default` | Keyboard type (`Email`, `Numeric`, `Telephone`, etc.) |
| `FontSize` | `double` | `14` | Input font size |
| `TextColor` | `Color` | platform default | Input text color |
| `PlaceholderColor` | `Color` | platform default | Placeholder text color |
| `BorderVisible` | `bool` | `false` | Show a rectangular border around the control |
| `BorderColor` | `Color` | `Transparent` | Border color when valid |
| `ErrorBorderColor` | `Color` | `Red` | Border color when invalid |
| `CornerRadius` | `double` | `0` | Corner radius of the border |
| `SeparatorVisible` | `bool` | `false` | Show a 1 px line above the error message when invalid |
| `ErrorSeparatorColor` | `Color` | `Red` | Separator color when invalid |
| `ErrorColor` | `Color` | `Red` | Error message text color |
| `ErrorFontSize` | `double` | `12` | Error message font size |

### Events

| Event | Description |
|---|---|
| `TextChanged` | Raised when the input text changes |
