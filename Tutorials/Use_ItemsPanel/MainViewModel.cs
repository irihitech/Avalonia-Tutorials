using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ursa.Controls;

namespace Use_ItemsPanel;

public class MainViewModel: ObservableObject
{
    public List<Item> Items { get; set; }

    public MainViewModel()
    {
        Items = new List<Item>()
        {
            new (){ ItemContent = "Item 1" },
            new (){ ItemContent = "Item 2" },
            new (){ ItemContent = "Item 3" },
            new (){ ItemContent = "Item 4" },
            new (){ ItemContent = "Item 5" },
            new (){ ItemContent = "Item 6" },
            new (){ ItemContent = "Item 7" },
            new (){ ItemContent = "Item 8" },
            new (){ ItemContent = "Item 9" },
            new (){ ItemContent = "Item 10" },
        };
    }
}

public class Item
{
    public string? ItemContent { get; set; }
    public ICommand ClickCommand { get; set; }

    public Item()
    {
        ClickCommand = new RelayCommand(OnClick);
    }

    private void OnClick()
    {
        MessageBox.ShowOverlayAsync($"Hello {ItemContent}");
    }
}