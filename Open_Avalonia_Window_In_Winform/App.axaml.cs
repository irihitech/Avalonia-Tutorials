using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WinFormsApp;

public partial class App : Avalonia.Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}