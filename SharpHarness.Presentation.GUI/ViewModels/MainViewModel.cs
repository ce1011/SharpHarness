using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using SharpHarness.Presentation.GUI.Models;

namespace SharpHarness.Presentation.GUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Tasks =
        [
            new("Build cockpit POC", "3 files · approval pending", TaskState.Active),
            new("Review window shell", "waiting", TaskState.Queued),
        ];

        ContextItems =
        [
            new("AGENTS.md", "RULE"),
            new("Views/MainWindow.axaml", "FILE"),
            new("Styles/ThemeResources.axaml", "FILE"),
        ];

        Tools =
        [
            new("Filesystem", "ready", true),
            new("LSP", "ready", true),
            new("Shell", "ready", true),
        ];

        Files =
        [
            new("Views/MainWindow.axaml", ChangeStatus.Modified, 64, 12, true),
            new("Styles/ThemeResources.axaml", ChangeStatus.Added, 128, 0, false),
            new("ViewModels/MainViewModel.cs", ChangeStatus.Modified, 8, 4, false),
        ];
        SelectedFile = Files[0];

        DiffLines =
        [
            new("20", DiffLineKind.Context, "    <Grid RowDefinitions=\"56,*,Auto\">"),
            new(string.Empty, DiffLineKind.Removed, "        <TextBlock Text=\"{Binding Greeting}\""),
            new(string.Empty, DiffLineKind.Removed, "                   HorizontalAlignment=\"Center\" />"),
            new("21", DiffLineKind.Added, "        <Grid ColumnDefinitions=\"230,*,400\">"),
            new("22", DiffLineKind.Added, "            <Border Grid.Column=\"0\" /> <!-- context -->"),
            new("23", DiffLineKind.Added, "            <Border Grid.Column=\"1\" /> <!-- agent -->"),
            new("24", DiffLineKind.Added, "            <Border Grid.Column=\"2\" /> <!-- changes -->"),
            new("25", DiffLineKind.Added, "        </Grid>"),
            new("26", DiffLineKind.Context, "    </Grid>"),
            new("27", DiffLineKind.Context, "</Window>"),
        ];

        Tests =
        [
            new("MainWindow builds without warnings", "2.1s"),
            new("Drawer collapses to status bar", "31ms"),
            new("Theme resources resolve", "8ms"),
        ];
    }

    [ObservableProperty] public partial string SelectedModel { get; set; } = "Claude Sonnet 4.5";

    public string BranchName => "feature/cockpit-poc";
    public string CommitHash => "a4f2c91";
    public string TokenUsage => "42.3k / 128k";
    public string Cost => "$1.84";
    public string Status => "Awaiting approval";
    public string RunLabel => "Run 12";
    public string Elapsed => "02:14";
    public string ChangedFileCount => "3 files";
    public string TotalAdded => "+200";
    public string TotalRemoved => "−16";

    public IReadOnlyList<string> ModelOptions =>
    [
        "Claude Sonnet 4.5",
        "GPT-5.2 Codex",
        "Gemini 3 Pro",
    ];

    public IReadOnlyList<TaskItem> Tasks { get; }
    public IReadOnlyList<ContextItem> ContextItems { get; }
    public IReadOnlyList<ToolItem> Tools { get; }
    public IReadOnlyList<ChangedFileInfo> Files { get; }
    public ChangedFileInfo SelectedFile { get; }
    public IReadOnlyList<DiffLineInfo> DiffLines { get; }
    public IReadOnlyList<TestResultInfo> Tests { get; }
}
