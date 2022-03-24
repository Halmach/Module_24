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
            string currentCommand = string.Empty;
            do
            {
                Console.WriteLine("Список команд для работы консоли:");
                Console.WriteLine(Commands.stop + ": прекращение работы");
                Console.WriteLine(Commands.add + ": добавление данных");
                Console.WriteLine(Commands.delete + ": удаление данных");
                Console.WriteLine(Commands.update + ": обновление данных");
                Console.WriteLine(Commands.show + ": просмотр данных");

                currentCommand = Console.ReadLine().Trim().ToLower();

                switch(currentCommand)
                {
                    case nameof(Commands.add): Create(); break;
                    case nameof(Commands.show): manager.ShowData(); break;
                    case nameof(Commands.update): Update(); break;
                    case nameof(Commands.delete): Delete(); break;
                }

            } while (currentCommand != nameof(Commands.stop));

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
