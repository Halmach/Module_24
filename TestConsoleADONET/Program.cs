using Microsoft.Data.SqlClient;
using System;
using TestADONETProject;

namespace TestConsoleADONET
{
    class Program
    {
        static void Main(string[] args)
        {


            var connector = new MainConnector();
            var result = connector.ConnectAsync();

            if(result.Result)
            {
                Console.WriteLine("Подключено успешно!");
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
