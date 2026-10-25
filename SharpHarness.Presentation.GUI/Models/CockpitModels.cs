namespace SharpHarness.Presentation.GUI.Models;

public enum TaskState
{
    Active,
    Queued,
}

public enum ChangeStatus
{
    Modified,
    Added,
}

public enum DiffLineKind
{
    Context,
    Added,
    Removed,
}

public sealed record TaskItem(string Title, string Meta, TaskState State)
{
    public bool IsActive => State == TaskState.Active;
    public bool IsQueued => State == TaskState.Queued;
}

public sealed record ContextItem(string Name, string Kind);

public sealed record ToolItem(string Name, string State, bool IsHealthy);

public sealed record ChangedFileInfo(
    string Path,
    ChangeStatus Status,
    int Added,
    int Removed,
    bool IsSelected)
{
    public bool IsAddedFile => Status == ChangeStatus.Added;
    public string StatusLetter => Status == ChangeStatus.Added ? "A" : "M";
    public string AddedText => $"+{Added}";
    public string RemovedText => Removed > 0 ? $"-{Removed}" : string.Empty;
    public bool HasRemoved => Removed > 0;
}

public sealed record DiffLineInfo(string Number, DiffLineKind Kind, string Text)
{
    public bool IsAdded => Kind == DiffLineKind.Added;
    public bool IsRemoved => Kind == DiffLineKind.Removed;
    public string Sign => Kind switch
    {
        DiffLineKind.Added => "+",
        DiffLineKind.Removed => "-",
        _ => string.Empty,
    };
}

public sealed record TestResultInfo(string Name, string Duration);
