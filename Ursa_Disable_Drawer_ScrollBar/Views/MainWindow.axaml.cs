using Avalonia.Controls;
using Avalonia.Interactivity;
using Ursa_Disable_Drawer_ScrollBar.ViewModels;
using Ursa.Controls;
using Ursa.Controls.Options;

namespace Ursa_Disable_Drawer_ScrollBar.Views;

public partial class MainWindow : UrsaWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var options = new DrawerOptions()
        {
            MaxWidth = 400,
            StyleClass = "DisableHorizontal",
        };
        await Drawer.ShowCustomModal<CustomDialogView, CustomDialogViewModel, object>(new CustomDialogViewModel(),
            options: options);

    }
}