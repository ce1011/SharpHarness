using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SharpHarness.Presentation.GUI.Views;

public partial class MainWindow : Window
{
    private bool _isDrawerOpen = true;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnToggleDrawerClick(object? sender, RoutedEventArgs e)
    {
        _isDrawerOpen = !_isDrawerOpen;
        DrawerContent.IsVisible = _isDrawerOpen;
        VerificationDrawer.Height = _isDrawerOpen ? 220 : 34;
        CollapseChevron.IsVisible = _isDrawerOpen;
        ExpandChevron.IsVisible = !_isDrawerOpen;
    }
}
