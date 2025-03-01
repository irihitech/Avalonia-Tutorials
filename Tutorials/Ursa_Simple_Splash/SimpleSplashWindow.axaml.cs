using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Ursa.Controls;

namespace Ursa_Simple_Splash;

public partial class SimpleSplashWindow : SplashWindow
{
    public SimpleSplashWindow()
    {
        InitializeComponent();
    }

    protected async override Task<Window?> CreateNextWindow()
    {
        return new MainWindow();
    }
}