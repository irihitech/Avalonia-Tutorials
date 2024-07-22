using Avalonia.Controls;
using Avalonia.Interactivity;
using Ursa.Controls;
using UrsaNativeAOT;

namespace Ursa_NativeAOT;

public partial class MainWindow : UrsaWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        MessageBox.ShowOverlayAsync("Hello from AOT compiled Ursa!", "Message");
    }

    private async void Button_Dialog(object? sender, RoutedEventArgs e)
    {
        await OverlayDialog.ShowModal<DemoDialog, string>("Hello");
    }

    private async void Button_Drawer(object? sender, RoutedEventArgs e)
    {
        await Drawer.ShowModal<DemoDialog, string>("Hello");
    }
}