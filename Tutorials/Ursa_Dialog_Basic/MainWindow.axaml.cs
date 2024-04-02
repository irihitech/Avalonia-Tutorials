using Avalonia.Controls;
using Avalonia.Interactivity;
using Ursa.Controls;

namespace Ursa_Dialog_Basic;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        await OverlayDialog.ShowModal<DialogContent, object>(new object());
    }
}