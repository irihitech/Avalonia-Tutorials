using System.Collections.ObjectModel;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace DataGrid_With_DataTable;

public class DataTableBindingHelper
{

    public static readonly AttachedProperty<object?> TableBindingProperty =
        AvaloniaProperty.RegisterAttached<DataTableBindingHelper, DataGrid, object?>("TableBinding");
    
    public static void SetTableBinding(DataGrid obj, object? value) => obj.SetValue(TableBindingProperty, value);
    public static object? GetTableBinding(DataGrid obj) => obj.GetValue(TableBindingProperty);

    static DataTableBindingHelper()
    {
        TableBindingProperty.Changed.AddClassHandler<DataGrid, object?>(OnBindingChanged);
    }

    private static void OnBindingChanged(DataGrid grid, AvaloniaPropertyChangedEventArgs<object?> args)
    {
        var table = args.NewValue.Value as DataTable;
        grid.ItemsSource = table?.Rows;
        foreach (DataColumn column in table.Columns)
        {
            grid.Columns.Add(new DataGridTextColumn()
            {
                Header = column.ColumnName,
                Binding = new Binding(column.ColumnName)
            });
        }
        
    }
}