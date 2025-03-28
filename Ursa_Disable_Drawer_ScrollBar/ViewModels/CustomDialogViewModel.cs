using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ursa_Disable_Drawer_ScrollBar.ViewModels;

public class CustomDialogViewModel: ObservableObject
{
    public ObservableCollection<string> Items { get; set; }

    public CustomDialogViewModel()
    {
        Items = new ObservableCollection<string>(Enumerable.Range(0, 1000).Select(a => a.ToString()));
        
    }
}