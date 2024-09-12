using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Form_Dynamic_Generation.ViewModels.FormViewModels;

public partial class SelectFormItemViewModel: ObservableObject, IFormItemViewModel
{
    [ObservableProperty] private string? _label;
    [ObservableProperty] private bool _isRequired;

    [ObservableProperty] private List<string>? _items;
    [ObservableProperty] private string? _selectedItem;
}