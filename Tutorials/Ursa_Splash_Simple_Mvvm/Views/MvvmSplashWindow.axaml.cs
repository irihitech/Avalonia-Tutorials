using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Ursa_Splash_Simple_Mvvm.ViewModels;
using Ursa.Controls;

namespace Ursa_Splash_Simple_Mvvm.Views;

public partial class MvvmSplashWindow : SplashWindow
{
    public MvvmSplashWindow()
    {
        InitializeComponent();
    }

    protected async override Task<Window?> CreateNextWindow()
    {
        return new MainWindow()
        {
            DataContext = new MainWindowViewModel()
        };
    }
}