using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Manipulating_ItemContainer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<string>? _items;
    [ObservableProperty] private string? _currentInteraction;

    public MainWindowViewModel()
    {
        Items = new ObservableCollection<string>(Enumerable.Range(0, 10000)
            .Select(a => "Item " + a));
    }
}
