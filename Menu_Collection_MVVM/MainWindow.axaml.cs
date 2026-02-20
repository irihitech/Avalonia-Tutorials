using Avalonia.Controls;

namespace Menu_Collection_MVVM;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }
}
