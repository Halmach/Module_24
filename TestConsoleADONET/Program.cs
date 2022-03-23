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

            var manager = new Manager();

            manager.Connect();

            manager.ShowData();

            Console.WriteLine("Введите логин для удаления");

            var deletedRowsNum = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine("Количество удаленных строк = " + deletedRowsNum);

            Console.WriteLine();

            manager.ShowData();

            manager.Disconnect();

            Console.ReadKey();






            //var connector = new MainConnector();
            //var result = connector.ConnectAsync();

            //string tableName = "NetworkUser";
            //DbExecutor db = new DbExecutor(connector);

            //var data = new DataTable();


            //if (result.Result)
            //{
            //    var sqlCommandResult = db.SelectAllbyCommandReader(tableName);

            //    var columnList = new List<string>();

            //    for (int i = 0; i < sqlCommandResult.FieldCount; i++)
            //    {
            //        var name = sqlCommandResult.GetName(i);
            //        columnList.Add(name);
            //    }

            //    // Отображение столбцов
            //    for (int i = 0; i < columnList.Count; i++)
            //    {
            //        Console.Write($"{columnList[i]}\t");
            //    }
            //    Console.WriteLine();

            //    // Чтение данных
            //    while (sqlCommandResult.Read())
            //    {
            //        for (int i = 0; i < columnList.Count; i++)
            //        {
            //            var value = sqlCommandResult[columnList[i]];
            //            Console.Write($"{value}\t");
            //        }

            //        Console.WriteLine();
            //    }
            //}
        }

        static void ReadFromNetworkUser()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
        }



       
    }
}
