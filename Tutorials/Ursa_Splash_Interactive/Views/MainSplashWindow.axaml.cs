using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Ursa_Splash_Interactive.ViewModels;
using Ursa.Controls;

namespace Ursa_Splash_Interactive.Views;

public partial class MainSplashWindow : SplashWindow
{
    public MainSplashWindow()
    {
        InitializeComponent();
    }

    protected async override Task<Window?> CreateNextWindow()
    {
        if (DialogResult is null) return null;
        if (DialogResult is not string s) return null;
        return new MainWindow()
        {
            DataContext = new MainWindowViewModel(s)
        };
    }
}