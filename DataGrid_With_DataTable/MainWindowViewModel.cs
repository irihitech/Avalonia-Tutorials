using System.Data;

namespace DataGrid_With_DataTable;

public class MainWindowViewModel
{
    public DataTable Table { get; set; }

    public MainWindowViewModel()
    {
        Table = new DataTable();
        Table.Columns.Add("Name", typeof(string));
        Table.Columns.Add("Age", typeof(int));
        Table.Rows.Add("John Doe", 42);
        Table.Rows.Add("Jane Doe", 39);
        var row = Table.Rows[0];
        var columns = Table.Columns;
    }
}