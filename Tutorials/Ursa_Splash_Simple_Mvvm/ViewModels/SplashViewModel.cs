using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Irihi.Avalonia.Shared.Contracts;

namespace Ursa_Splash_Simple_Mvvm.ViewModels;

public partial class SplashViewModel: ObservableObject, IDialogContext
{
    [ObservableProperty] private double _progress;
    [ObservableProperty] private string? _message;

    public SplashViewModel()
    {
        Progress = 0;
        DispatcherTimer.Run(OnRun, TimeSpan.FromMilliseconds(100), DispatcherPriority.Normal);
    }
    
    private string[] Messages { get; } = new[]
    {
        "Loading...",
        "Please wait...",
        "Almost there...",
        "Finishing up...",
        "Done!"
    };

    private bool OnRun()
    {
        Progress += 5;
        if (Progress % 20 == 0)
        {
            Message = Messages[(int)Progress / 20 - 1];
        }
        if (Progress >= 100)
        {
            RequestClose?.Invoke(this, true);
            return false;
        }
        return true;
    }

    public void Close()
    {
        RequestClose?.Invoke(this, null);
    }

    public event EventHandler<object?>? RequestClose;
}