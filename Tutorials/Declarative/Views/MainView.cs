using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Markup.Declarative;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Declarative.ViewModels;
using Ursa.Controls;

namespace Declarative.Views;

public class MainView: ViewBase<MainWindowViewModel>
{
    public MainView():base(new MainWindowViewModel())
    {
        
    }
    public MainView(MainWindowViewModel viewModel) : base(viewModel)
    {
    }

    protected override object Build(MainWindowViewModel? vm)
    {
        if (vm is null) return new TextBlock().Text("Empty");
        var group = new ButtonGroup()
            .ItemsSource(@vm.Items)
            .ItemTemplate(new FuncDataTemplate<ButtonItem>(
                a => true,
                a => new TextBlock().Text("🐼" + a.Name).FontWeight(FontWeight.Medium))
            );
        group.CommandBinding = new Binding(nameof(ButtonItem.InvokeCommand));
        return group;
    }
}