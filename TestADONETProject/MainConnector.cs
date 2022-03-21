using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TestADONETProject
{
    public class MainConnector
    {
        SqlConnection connection;
        public async Task <bool> ConnectAsync()
        {
            bool result;
            
            try
            {
                connection = new SqlConnection(ConnectionString.MsSQLConnection);
                await connection.OpenAsync();
                result = true;
            }
            catch(Exception e)
            {
                result = false;
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public async void DisconnectAsync()
        {
            if(connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }

        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Open) return connection;
            else throw new Exception("Подключение уже закрыто");
        }
    }
}
