# How to Disable Ursa Drawer ScrollBar

# 如何禁用Ursa Drawer 滚动条

Ursa Dialog and Drawer components have a scroll bar by default. This can be disabled with global style. Specify the defined StyleClass in the options when calling the ShowCustomModal method.

Ursa Dialog 和 Drawer 组件默认有滚动条。可以通过全局样式禁用它。 在调用 ShowCustomModal 方法时在选项中指定定义的 StyleClass。

```xml
<Style Selector="u|CustomDrawerControl.DisableHorizontal">
    <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"></Setter>
</Style>
```

```csharp
var options = new DrawerOptions()
    {
        MaxWidth = 400,
        StyleClass = "DisableHorizontal",
    };
await Drawer.ShowCustomModal<CustomDialogView, CustomDialogViewModel, object>(new CustomDialogViewModel(), options: options);
```

This can be applied to `DefaultDialogControl`, `CustomDialogControl`, `DefaultDrawerControl`, `CustomDrawerControl`

这同样可以应用于 `DefaultDialogControl`、`CustomDialogControl`、`DefaultDrawerControl`、`CustomDrawerControl`