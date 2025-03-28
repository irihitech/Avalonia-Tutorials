using CommunityToolkit.Mvvm.ComponentModel;

namespace Ursa_Splash_Interactive.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting;
    public MainWindowViewModel(string userName)
    {
        Greeting = $"Hello, {userName}!";
    }
}