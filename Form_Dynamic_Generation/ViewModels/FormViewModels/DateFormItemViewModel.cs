using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Form_Dynamic_Generation.ViewModels.FormViewModels;

public partial class DateFormItemViewModel: ObservableObject, IFormItemViewModel
{
    [ObservableProperty] private string? _label;

    [ObservableProperty] private bool _isRequired;

    [ObservableProperty] private DateTime? _date;
}