using Avalonia.Controls;

namespace Use_ItemsPanel;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }
}