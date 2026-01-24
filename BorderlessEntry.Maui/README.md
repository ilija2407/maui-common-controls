# BorderlessEntry.Maui

Borderless Entry control for .NET MAUI with Android/iOS handler mappings.

## Installation

Add a PackageReference to your app/project:

```xml
<ItemGroup>
  <PackageReference Include="BorderlessEntry.Maui" Version="1.0.0" />
</ItemGroup>
```

## Setup (MauiProgram.cs)

Register the handler mapping once during app startup:

```csharp
using BorderlessEntry.Maui.Hosting;

// ...

builder.UseBorderlessEntry();
```

## XAML usage

```xml
xmlns:be="clr-namespace:BorderlessEntry.Maui.Controls;assembly=BorderlessEntry.Maui"

<be:BorderlessEntry Placeholder="Email" />
```
