using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;

namespace SqlConnTest
{
    class Program
    {
        public static string ConvertDataTableToString(DataTable dataTable)
        {
            string data = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    data += dataTable.Columns[j].ColumnName + "~" + row[j];
                    if (j == dataTable.Columns.Count - 1)
                    {
                        if (i != (dataTable.Rows.Count - 1))
                            data += "$";
                    }
                    else
                        data += "|";
                }
            }
            return data;
        }

        static void TestSQL()
        {
            using (SqlConnection con = new SqlConnection("Data Source=127.0.0.1,1833;Initial Catalog=MyTestDB;User ID=sa;Password=Password12!;"))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Customers", con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        var tb = new DataTable();
                        tb.Load(reader);
                        Console.WriteLine($"Data {ConvertDataTableToString(tb)}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception {ex}");
                }
            }
        }

        static void Main(string[] args)
        {
            TestSQL();
        }
    }
}
