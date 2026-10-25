# AGENTS.md

Single-project Avalonia desktop app (MVVM). There is no README, test project, lint config, or CI — verify changes with a build.

## Tool Selection & IDE Integration

- **Prefer Rider MCP**: Prioritize Rider MCP tools over standard bash commands or generic text search for all C#/.NET tasks.
- **Code Navigation & Search**: Use Rider MCP symbol search, definition lookup, find references, and type hierarchy rather than `grep`, `find`, or text-based matching.
- **Inspections & Diagnostics**: Rely on Rider MCP code analysis and diagnostic inspections to verify changes and identify errors.
- **Refactoring & Edits**: Prefer Rider MCP refactoring and structural editing capabilities whenever modifying C# classes, methods, or namespaces.
- **Build & Test**: Trigger builds and test runs via Rider MCP actions before falling back to `dotnet` CLI commands.

## Commands

- Build: `dotnet build SharpHarness.slnx` (note the `.slnx` solution format; targets `net10.0`, SDK 10, no `global.json` pin).
- Run: `dotnet run --project SharpHarness.Presentation.GUI`. This launches the GUI and blocks until the window closes, so use the build command for automated verification.
- `dotnet test` has nothing to run until a test project is added; don't claim test coverage.

## Layout and wiring

- `SharpHarness.Presentation.GUI/` is the only project; root namespace `SharpHarness.Presentation.GUI`.
- Startup: `Program.Main` → `App.OnFrameworkInitializationCompleted`, which creates `MainWindow` and sets `MainViewModel` directly. There is no DI container or service registration.
- Views live in `Views/`, view models in `ViewModels/`. `ViewLocator` (registered in `App.axaml`) reflects `...ViewModels.FooViewModel` to `...Views.FooView`; mismatched names/namespaces show "Not Found: ...". `MainWindow` itself is constructed directly, not through the locator.
- `MainWindow.axaml` sets `x:DataType`; update it when changing the view model type used for bindings/design-time support.
- Files under `Assets/` are automatically included as `AvaloniaResource` via the csproj wildcard.

## Conventions

- Follow `MainViewModel`'s MVVM Toolkit style: derive from `ViewModelBase` and use `[ObservableProperty] public partial ...` properties (MVVM Toolkit 8.4 + C# 14 partial properties).
- Avalonia developer tools are Debug-only (`WithDeveloperTools` in `Program.cs`; diagnostics package excluded from non-Debug builds).
- The app uses Windows-flavored project settings (`WinExe`, `app.manifest`), although Avalonia.Desktop itself is cross-platform.
