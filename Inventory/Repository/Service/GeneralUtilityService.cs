using System.Data;

namespace Inventory.Repository.Service;

public class GeneralUtilityService
{
    public List<Dictionary<string, object>> ConvertDataTableToDictionaryList(DataTable dt)
    {
        var columns = dt.Columns.Cast<DataColumn>();
        var dataList = new List<Dictionary<string, object>>();

        foreach (DataRow row in dt.Rows)
        {
            var dataColumns = columns.ToList();
            var rowDict = dataColumns.ToDictionary(col => col.ColumnName, col => row[col]);
            dataList.Add(rowDict);
        }

        return dataList;
    }

}