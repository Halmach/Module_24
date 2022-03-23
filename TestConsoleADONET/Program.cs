using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
            DbExecutor db;
            string tableName;

            var data = new DataTable();

            //if(result.Result)
            //{
            //    Console.WriteLine("Подключено успешно!");

            //    db = new DbExecutor(connector);

            //    tableName = "NetworkUser";

            //    Console.WriteLine("Получаем данные таблицы " + tableName);

            //    data = db.SelectAll(tableName);

            //    Console.WriteLine("Количество строк в " + tableName + ": " + data.Rows.Count);

            //    Console.WriteLine("Отключаем БД!");
            //    connector.DisconnectAsync();

            //    Console.WriteLine("Количество строк в " + tableName + ": " + data.Rows.Count);



            //    Console.WriteLine();


            //    foreach(DataRow row in data.Rows)
            //    {
            //        var cells = row.ItemArray;
            //        foreach (var cell in cells)
            //        {
            //            Console.Write($"{cell}\n");
            //        }
            //    }


            //    Console.WriteLine("--------------------------------------------");

            //    // вывод наименования столбцов
            //    foreach (DataColumn column in data.Columns)
            //    {
            //        Console.Write($"{column.ColumnName}\t");
            //    }

            //    Console.WriteLine();

            //    foreach (DataRow row in data.Rows)
            //    {
            //        for (int i = 0; i < data.Columns.Count; i++)
            //            Console.Write($"{row[data.Columns[i].ColumnName]}\t");
            //        Console.WriteLine();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Ошибка подключения");
            //}

            if (result.Result)
            {

                tableName = "NetworkUser";
                db = new DbExecutor(connector);
                var sqlCommandResult = db.SelectAllbyCommandReader(tableName);

                var columnList = new List<string>();

                for (int i = 0; i < sqlCommandResult.FieldCount; i++)
                {
                    var name = sqlCommandResult.GetName(i);
                    columnList.Add(name);
                }

                // Отображение столбцов
                for (int i = 0; i < columnList.Count; i++)
                {
                    Console.Write($"{columnList[i]}\t");
                }
                Console.WriteLine();

                // Чтение данных
                while (sqlCommandResult.Read())
                {
                    for (int i = 0; i < columnList.Count; i++)
                    {
                        var value = sqlCommandResult[columnList[i]];
                        Console.Write($"{value}\t");
                    }

                    Console.WriteLine();
                }
            }
        }

        static void ReadFromNetworkUser()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
        }

       
    }
}
