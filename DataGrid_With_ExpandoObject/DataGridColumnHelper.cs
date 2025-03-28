using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Reactive;

namespace DataGrid_With_ExpandoObject;

public class DataGridColumnHelper
{
    public static readonly AttachedProperty<bool> DeriveExpandoColumnsProperty =
        AvaloniaProperty.RegisterAttached<DataGridColumnHelper, DataGrid, bool>("Columns");

    public static void SetDeriveExpandoColumns(DataGrid obj, bool value) => obj.SetValue(DeriveExpandoColumnsProperty, value);
    public static bool GetDeriveExpandoColumns(DataGrid obj) => obj.GetValue(DeriveExpandoColumnsProperty);

    static DataGridColumnHelper()
    {
        DeriveExpandoColumnsProperty.Changed.AddClassHandler<DataGrid, bool>(OnAttributeAttached);
    }

    private static void OnAttributeAttached(DataGrid arg1, AvaloniaPropertyChangedEventArgs<bool> arg2)
    {
        if (arg2.NewValue.Value)
        {
            arg1.GetObservable(DataGrid.ItemsSourceProperty)
                .Subscribe(new AnonymousObserver<IEnumerable>(a => OnItemsSourceChanged2(a, arg1)));
        }
    }
    
    private static void OnItemsSourceChanged2(IEnumerable obj, DataGrid grid)
    {
        if (obj is not IEnumerable<ExpandoObject> expandoObjects) return;
        var columns = new Dictionary<string, DataGridColumn>();
        var sampleObject = expandoObjects.FirstOrDefault();
        if (sampleObject is null) return;
        foreach (var (key, value) in sampleObject)
        {
            if (value is int i)
            {
                // Add your own logic here if you have different column for different data types. 
                columns[key] = new DataGridTextColumn()
                {
                    Header = key,
                    Binding = new Binding(key)
                };
            }
            else if(value is bool b)
            {
                // Add your own logic here if you have different column for different data types. 
                columns[key] = new DataGridCheckBoxColumn()
                {
                    Header = key,
                    Binding = new Binding(key)
                };
            }
            else
            {
                columns[key] = new DataGridTextColumn()
                {
                    Header = key,
                    Binding = new Binding(key)
                };
            }
        }
        grid.Columns.Clear();
        foreach (var column in columns)
        {
            grid.Columns.Add(column.Value);
        }
    }

    
}