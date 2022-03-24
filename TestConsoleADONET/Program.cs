using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TestADONETProject;

namespace TestConsoleADONET
{
    class Program
    {
        static Manager manager = new Manager();
        static void Main(string[] args)
        {
            manager.Connect();

            Delete();
            Create();
            Update();

            manager.Disconnect();
            Console.ReadKey();
        }

        static void Delete()
        {
            manager.ShowData();

            Console.WriteLine("Введите логин для удаления");

            var deletedRowsNum = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine("Количество удаленных строк = " + deletedRowsNum);

            Console.WriteLine();
        }

        static void Create()
        {
            manager.ShowData();

            Console.WriteLine("Введите имя пользователя:");

            var name = Console.ReadLine();

            Console.WriteLine("Введите логин:");

            var login = Console.ReadLine();

            manager.AddingUser(name, login);

            Console.WriteLine();
        }

        static void Update()
        {
            manager.ShowData();

            Console.WriteLine("Введите логин:");

            var login = Console.ReadLine();

            Console.WriteLine("Введите новое имя пользователя");

            var newName = Console.ReadLine();

            manager.UpdateUserByLogin(newName, login);

            Console.WriteLine();

            manager.ShowData();
        }

       
    }
}
