using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Menu_Collection_MVVM;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _lastAction = "No action yet.";

    public ObservableCollection<MenuItemViewModel> MenuItems { get; }

    public MainViewModel()
    {
        MenuItems = new ObservableCollection<MenuItemViewModel>
        {
            new MenuItemViewModel("File")
            {
                SubItems = new ObservableCollection<MenuItemViewModel>
                {
                    new MenuItemViewModel("New", () => LastAction = "File > New clicked"),
                    new MenuItemViewModel("Open", () => LastAction = "File > Open clicked"),
                    new MenuItemViewModel("Save", () => LastAction = "File > Save clicked"),
                    new MenuItemViewModel("-"),
                    new MenuItemViewModel("Exit", () => LastAction = "File > Exit clicked"),
                }
            },
            new MenuItemViewModel("Edit")
            {
                SubItems = new ObservableCollection<MenuItemViewModel>
                {
                    new MenuItemViewModel("Cut", () => LastAction = "Edit > Cut clicked"),
                    new MenuItemViewModel("Copy", () => LastAction = "Edit > Copy clicked"),
                    new MenuItemViewModel("Paste", () => LastAction = "Edit > Paste clicked"),
                }
            },
            new MenuItemViewModel("Help")
            {
                SubItems = new ObservableCollection<MenuItemViewModel>
                {
                    new MenuItemViewModel("About", () => LastAction = "Help > About clicked"),
                }
            },
        };
    }
}

public partial class MenuItemViewModel : ObservableObject
{
    public string Header { get; }

    public ObservableCollection<MenuItemViewModel>? SubItems { get; set; }

    public IRelayCommand? Command { get; }

    public MenuItemViewModel(string header, System.Action? action = null)
    {
        Header = header;
        if (action is not null)
        {
            Command = new RelayCommand(action);
        }
    }
}
