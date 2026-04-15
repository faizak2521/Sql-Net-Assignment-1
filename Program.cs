using System;
using System.IO;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=SalesComp.db";

        using SqliteConnection conn = new SqliteConnection(connectionString);
        conn.Open();

        WriteReport(conn, @"SELECT I.INV_NUMBER, I.INV_DATE, C.CUST_LNAME, C.CUST_FNAME
        FROM Invoice I
        JOIN Customer C ON I.CUST_CODE = C.CUST_CODE;", "report1.txt");

        WriteReport(conn, @"SELECT P.PROD_CODE, P.PROD_DESCRIPT, V.VEND_NAME
        FROM Product P
        LEFT JOIN Vendor V ON P.VEND_CODE = V.VEND_CODE;", "report2.txt");

        WriteReport(conn, @"SELECT L.INV_NUMBER, L.LINE_NUMBER, P.PROD_DESCRIPT, L.LINE_UNITS, L.LINE_PRICE
        FROM Line L
        JOIN Product P ON L.PROD_CODE = P.PROD_CODE;", "report3.txt");

        WriteReport(conn, @"SELECT I.INV_NUMBER, C.CUST_LNAME, P.PROD_DESCRIPT, L.LINE_UNITS, L.LINE_PRICE
        FROM Line L
        JOIN Invoice I ON L.INV_NUMBER = I.INV_NUMBER
        JOIN Customer C ON I.CUST_CODE = C.CUST_CODE
        JOIN Product P ON L.PROD_CODE = P.PROD_CODE;", "report4.txt");

        WriteReport(conn, @"SELECT C.CUST_LNAME, C.CUST_FNAME, I.INV_NUMBER
        FROM Customer C
        LEFT JOIN Invoice I ON C.CUST_CODE = I.CUST_CODE;", "report5.txt");
    }

    static void WriteReport(SqliteConnection conn, string query, string fileName)
    {
        using SqliteCommand cmd = new SqliteCommand(query, conn);
        using SqliteDataReader reader = cmd.ExecuteReader();

        using StreamWriter writer = new StreamWriter(fileName);

        // Write headers
        for (int i = 0; i < reader.FieldCount; i++)
        {
            writer.Write(reader.GetName(i) + "\t");
        }
        writer.WriteLine();

        // Write rows
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                writer.Write(reader.GetValue(i) + "\t");
            }
            writer.WriteLine();
        }

        Console.WriteLine($"Generated {fileName}");
    }
}
