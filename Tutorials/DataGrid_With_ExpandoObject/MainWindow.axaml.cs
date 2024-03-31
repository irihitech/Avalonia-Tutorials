using Avalonia.Controls;

namespace DataGrid_With_ExpandoObject;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainWindowViewModel();
    }
}