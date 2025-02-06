using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Tree_Expand_Event;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TreeViewItem_OnExpanded(object? sender, RoutedEventArgs e)
    {
        if (e.Source is TreeViewItem item)
        {
            text.Text = item.Header +" Expanded";
        }
    }

    private void TreeViewItem_OnCollapsed(object? sender, RoutedEventArgs e)
    {
        if (e.Source is TreeViewItem item)
        {
            text.Text = item.Header +" Collapsed";
        }
    }
}