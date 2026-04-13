using System;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=Computer_Software.db";

        using SqliteConnection conn = new SqliteConnection(connectionString);
        conn.Open();

        RunQuery(conn, "Computer");
        RunQuery(conn, "Employee");
        RunQuery(conn, "Package");
        RunQuery(conn, "PC");
        RunQuery(conn, "Software");
    }

    static void RunQuery(SqliteConnection conn, string tableName)
    {
        Console.WriteLine($"\n--- {tableName} Table ---");

        string query = $"SELECT * FROM {tableName};";

        using SqliteCommand cmd = new SqliteCommand(query, conn);
        using SqliteDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)} ");
            }
            Console.WriteLine();
        }
    }
}
