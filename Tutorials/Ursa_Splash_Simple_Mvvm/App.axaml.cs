using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Ursa_Splash_Simple_Mvvm.ViewModels;
using Ursa_Splash_Simple_Mvvm.Views;

namespace Ursa_Splash_Simple_Mvvm;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MvvmSplashWindow()
            {
                DataContext = new SplashViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}