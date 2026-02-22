# CommonControls.Maui

Common borderless controls for .NET MAUI (Entry, Editor, PasswordEntry) with Android/iOS handler mappings.

## Installation

Add a PackageReference to your app/project:

```xml
<ItemGroup>
  <PackageReference Include="CommonControls.Maui" Version="1.0.2" />
</ItemGroup>
```

## Setup (MauiProgram.cs)

Register the handler mappings once during app startup:

```csharp
using CommonControls.Maui.Hosting;

// ...

builder.UseCommonControls();
```

## XAML usage

```xml
xmlns:cc="clr-namespace:CommonControls.Maui.Controls;assembly=CommonControls.Maui"

<cc:BorderlessEntry Placeholder="Email" />
<cc:BorderlessEditor Placeholder="Notes" HeightRequest="100" />

<!-- Password with built-in show/hide toggle (default eye icons) -->
<cc:PasswordEntry Placeholder="Password" />

<!-- Password with custom icons -->
<cc:PasswordEntry
    Placeholder="Password"
    ShowPasswordImageSource="my_eye.png"
    HidePasswordImageSource="my_hidden.png"
    ImageHeight="20"
    ImageWidth="20" />
```
