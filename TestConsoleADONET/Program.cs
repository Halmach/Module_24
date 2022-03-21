using Microsoft.Data.SqlClient;
using System;
using System.Data;
using TestADONETProject;

namespace TestConsoleADONET
{
    class Program
    {
        static void Main(string[] args)
        {


            var connector = new MainConnector();
            var result = connector.ConnectAsync();

            var data = new DataTable();

            if(result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                var db = new DbExecutor(connector);

                var tableName = "NetworkUser";

                Console.WriteLine("Получаем данные таблицы " + tableName);

                data = db.SelectAll(tableName);

                Console.WriteLine("Количество строк в " + tableName + ": " + data.Rows.Count);

                Console.WriteLine("Отключаем БД!");
                connector.DisconnectAsync();

                Console.WriteLine("Количество строк в " + tableName + ": " + data.Rows.Count);


                // вывод наименования столбцов
                foreach(DataColumn column in data.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}\t");
                }

                Console.WriteLine();


                foreach(DataRow row in data.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        Console.Write($"{cell}\n");
                    }
                }

                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ошибка подключения");
            }
        }

        static void ReadFromNetworkUser()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
        }
    }
}
