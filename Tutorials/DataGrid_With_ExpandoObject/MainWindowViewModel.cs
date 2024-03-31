using System.Collections.Generic;
using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGrid_With_ExpandoObject;

public class MainWindowViewModel: ObservableObject
{
    public List<ExpandoObject> Items { get; set; }

    public MainWindowViewModel()
    {
        Items = new List<ExpandoObject>(GenerateData());
    }

    private List<ExpandoObject> GenerateData()
    {
        List<ExpandoObject> result = new List<ExpandoObject>(100);
        for (int i = 0; i < 100; i++)
        {
            result.Add(GetData(i));
        }
        return result;
    }

    private ExpandoObject GetData(int i)
    {
        ExpandoObject obj = new ExpandoObject();
        IDictionary<string, object> dict = obj as IDictionary<string, object>;
        dict["Id"] = i;
        dict["Name"] = $"Name {i}";
        dict["Value"] = i * 10.0;
        return obj;
    }
}