using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Form_Dynamic_Generation.ViewModels.FormViewModels;

namespace Form_Dynamic_Generation.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<object> FormItems { get; set; } = [];

    public MainWindowViewModel()
    {
        FormItems.Add(new FormViewModels.TextFormItemViewModel() { Label = "First Name", IsRequired = false });
        FormItems.Add(new FormViewModels.DateFormItemViewModel() { Label = "Date of Birth", IsRequired = false });
        FormItems.Add(new FormViewModels.SelectFormItemViewModel() { Label = "Country", IsRequired = false, Items = [ "China", "USA", "Canada", "Mexico" ] });
        FormItems.Add(new FormViewModels.TextFormItemViewModel(){ Label = "Last Name", IsRequired = true });
        FormItems.Add(new FormViewModels.DateFormItemViewModel() { Label = "Date of Birth", IsRequired = true });
        FormItems.Add(new FormViewModels.SelectFormItemViewModel() { Label = "Country", IsRequired = true, Items = [ "China", "USA", "Canada", "Mexico" ] });
        
    }
}