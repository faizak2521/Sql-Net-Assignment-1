using System;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=SalesComp.db";

        using SqliteConnection conn = new SqliteConnection(connectionString);
        conn.Open(); 

        string sqlFilePath = Path.Combine(AppContext.BaseDirectory, "queries7.sql");

        if (!File.Exists(sqlFilePath))
        {
            sqlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "queries7.sql");
        }

        if (!File.Exists(sqlFilePath))
        {
            Console.WriteLine("Could not find queries7.sql");
            return;
        }

        string sqlText = File.ReadAllText(sqlFilePath);

        string[] queries = sqlText
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(q => q.Trim())
            .Where(q => !string.IsNullOrWhiteSpace(q))
            .ToArray();

        if (queries.Length < 5)
        {
            Console.WriteLine("queries7.sql must contain at least 5 queries.");
            return;
        }

        WriteReport(conn, queries[0], "report1.txt");
        WriteReport(conn, queries[1], "report2.txt");
        WriteReport(conn, queries[2], "report3.txt");
        WriteReport(conn, queries[3], "report4.txt");
        WriteReport(conn, queries[4], "report5.txt");
    }

    static void WriteReport(SqliteConnection conn, string query, string fileName)
    {
        using SqliteCommand cmd = new SqliteCommand(query, conn);
        using SqliteDataReader reader = cmd.ExecuteReader();

        using StreamWriter writer = new StreamWriter(fileName);
        decimal grandTotal = 0;
        decimal totalUnits = 0;
        decimal totalPrice = 0;

        // Write headers
        for (int i = 0; i < reader.FieldCount; i++)
        {
            string columnName = reader.GetName(i);
            int width = columnName == "PROD_DESCRIPT" ? -35 : -18;
            writer.Write(columnName.PadRight(Math.Abs(width)));
        }
        writer.WriteLine();

        // Write rows
        while (reader.Read())
        {
            // accumulate totals based on report
            if (fileName == "report1.txt")
            {
                if (reader.GetName(reader.FieldCount - 1).ToUpper() == "TOTAL")
                {
                    grandTotal += Convert.ToDecimal(reader[reader.FieldCount - 1]);
                }
            }
            else if (fileName == "report2.txt")
            {
                for (int j = 0; j < reader.FieldCount; j++)
                {
                    string col = reader.GetName(j).ToUpper();
                    if (col.Contains("UNITS"))
                        totalUnits += Convert.ToDecimal(reader[j]);
                    else if (col.Contains("PRICE") && !col.Contains("TOTAL"))
                        totalPrice += Convert.ToDecimal(reader[j]);
                    else if (col.Contains("TOTAL"))
                        grandTotal += Convert.ToDecimal(reader[j]);
                }
            }
            for (int i = 0; i < reader.FieldCount; i++)
            {
                object value = reader.GetValue(i);
                string columnName = reader.GetName(i);
                int width = columnName == "PROD_DESCRIPT" ? -35 : -18;

                if (columnName.ToUpper().Contains("DATE"))
                {
                    DateTime dt = Convert.ToDateTime(value);
                    writer.Write(dt.ToString("dd-MMM-yy").PadRight(Math.Abs(width)));
                }
                else if (value is double doubleValue)
                {
                    writer.Write(doubleValue.ToString("F2").PadRight(Math.Abs(width)));
                }
                else if (value is float floatValue)
                {
                    writer.Write(floatValue.ToString("F2").PadRight(Math.Abs(width)));
                }
                else if (value is decimal decimalValue)
                {
                    writer.Write(decimalValue.ToString("F2").PadRight(Math.Abs(width)));
                }
                else
                {
                    writer.Write((value?.ToString() ?? "").PadRight(Math.Abs(width)));
                }
            }
            writer.WriteLine();
        }

        // print totals section
        if (fileName == "report1.txt")
        {
            writer.WriteLine();
            writer.WriteLine("TOTALS".PadRight(20) + grandTotal.ToString("F2"));
        }
        else if (fileName == "report2.txt")
        {
            writer.WriteLine();
            writer.WriteLine("TOTALS:");
            writer.WriteLine($"Units: {totalUnits:F2}");
            writer.WriteLine($"Price: {totalPrice:F2}");
            writer.WriteLine($"Total: {grandTotal:F2}");
        }

        Console.WriteLine($"Generated {fileName}");
    }
}
