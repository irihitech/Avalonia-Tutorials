using Avalonia.Controls.Documents;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Form_Dynamic_Generation.ViewModels.FormViewModels;

public partial class TextFormItemViewModel: ObservableObject, IFormItemViewModel
{
    [ObservableProperty] private string? _label;
    [ObservableProperty] private bool _isRequired;
    [ObservableProperty] private string? _text;
}