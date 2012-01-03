using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace Lenovo.CFI.BLL
{
    public class CsvHelper
    {
        public static void ToCSV(string path, string[,] data)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            int row = data.GetLength(0);
            int column = data.GetLength(1);
            for (int j = 0; j < column; j++)
            {
                dt.Columns.Add(data[0, j], typeof(String));
            }

            for (int i = 0; i < row; i++)   //含表头
            {
                dt.Rows.Add(dt.NewRow());
                for (int j = 0; j < column; j++)
                {
                    if (!String.IsNullOrEmpty(data[i, j]))
                    {
                        dt.Rows[i][j] = "\"" + data[i, j].Replace("\"", "\"\"") + "\"";
                    }
                }
            }
            dt.AcceptChanges();

            CsvOptions options = new CsvOptions("String[,]", ',', data.GetLength(1));
            CsvEngine.DataTableToCsv(dt, path, options);
        }
    }
}
