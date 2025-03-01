using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Irihi.Avalonia.Shared.Contracts;

namespace Ursa_Splash_Interactive.ViewModels;

public partial class MainSplashViewModel:  ViewModelBase, IDialogContext
{
    public RelayCommand LeaveCommand { get; }
    public AsyncRelayCommand LoginCommand { get; }
    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private string _userName;
    [ObservableProperty] private string _password;

    public MainSplashViewModel()
    {
        LoginCommand = new AsyncRelayCommand(OnLogin);
        LeaveCommand = new RelayCommand(Close);
    }

    private async Task OnLogin()
    {
        IsLoading = true;
        await Task.Delay(3000);
        IsLoading = false;
        RequestClose?.Invoke(this, UserName);
    }

    public void Close()
    {
        RequestClose?.Invoke(this, null);
    }

    public event EventHandler<object?>? RequestClose;
}