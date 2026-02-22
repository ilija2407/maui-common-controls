# CommonControls.Maui

Common borderless controls for .NET MAUI (Entry, Editor) with Android/iOS handler mappings.

## Installation

Add a PackageReference to your app/project:

```xml
<ItemGroup>
  <PackageReference Include="CommonControls.Maui" Version="1.0.1" />
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
```
