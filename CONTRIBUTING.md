# Contributing to CommonControls.Maui

Contributions can include bug reports, examples, documentation, platform fixes, and new controls.

## Report a bug

[Open an issue](https://github.com/ilija2407/maui-common-controls/issues) with:

- The affected control and package version, or the source commit if you built locally.
- Your .NET SDK and MAUI versions, operating system, and device or emulator.
- A minimal XAML or C# example and steps to reproduce the problem.
- The expected and actual behavior, with screenshots or a short recording when useful.

Remove credentials and private application data from examples and logs.

## Suggest a control or API change

Describe the application scenario, the repetitive UI work the change would remove, and a proposed usage example. For a substantial new control or breaking API change, start with an issue so the scope can be discussed before implementation.

## Set up the repository

1. Fork and clone the repository.
2. Install a .NET 10 SDK and the MAUI workloads and platform tools needed for your target. The library also targets .NET 9; install compatible tooling when checking those targets.
3. Open `CommonControlsSample.slnx` and select `CommonControlsSample` as the startup project.
4. Build and run the sample on the platform affected by your change. Apple targets require a Mac and compatible Xcode tooling.

The main library lives in `CommonControls.Maui`. Platform mappings for borderless inputs are registered in `Hosting/CommonControlsAppBuilderExtensions.cs`; reusable controls live in `Controls`. The sample application references the main library project directly.

## Submit a pull request

- Keep changes focused and follow the surrounding C# and XAML style.
- Add or update a sample that demonstrates changed control behavior.
- Document public properties, defaults, setup requirements, and platform limitations in `CommonControls.Maui/README.md`. Update the root README if the control inventory or installation steps change.
- Check bindings, normal and error states, and busy/disabled states where relevant. For interaction changes, also check keyboard and accessibility behavior on the affected platforms.
- Build the affected framework and platform targets you can validate. State exactly which targets you checked and which you could not check.
- Include the problem, resulting behavior, validation performed, and screenshots or recordings for visual changes in your pull request description.

When changing package metadata, keep descriptions consistent with the implemented controls. Package versions and publication are managed separately from documentation changes.
