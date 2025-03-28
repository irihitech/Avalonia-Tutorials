using System.Data;
using Avalonia.Controls;

namespace DataGrid_With_DataTable;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}