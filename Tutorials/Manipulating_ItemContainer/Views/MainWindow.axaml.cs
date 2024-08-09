using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using Manipulating_ItemContainer.ViewModels;

namespace Manipulating_ItemContainer.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (e.Source is not Visual v) return;
        var item = v.FindAncestorOfType<ListBoxItem>();
        if (item is null) return;
        if (this.DataContext is MainWindowViewModel vm)
        {
            vm.CurrentInteraction = item.Content + " " + DateTime.Now.ToString("HH:mm:ss ff");
        }
    }
}