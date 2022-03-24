using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestADONETProject
{
    public class DbExecutor
    {
        private MainConnector connector;
        public DbExecutor(MainConnector connector)
        {
            this.connector = connector;
        }

        public DataTable SelectAll(string table)
        {
            var selectcommandtext = "select * from " + table;
            var adapter = new SqlDataAdapter(selectcommandtext, connector.GetConnection());

            var ds = new DataSet();
            adapter.Fill(ds);

            return ds.Tables[0];
        }

        public SqlDataReader SelectAllbyCommandReader(string table)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "select * from " + table,
                Connection = connector.GetConnection()
            };

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) return reader;

            return null;
        }

        // Задание 24.4.5
        public int DeleteFromTable(string table, string column, string value)
        {
            var commandText = "delete from " + table + " where " + column + " = '" + value + "';";
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = commandText,
                Connection = connector.GetConnection()
            };

            return command.ExecuteNonQuery();
        }

        // Задание 24.4.6
        public int DeleteByColumn(string table, string column, string value)
        {
            return DeleteFromTable(table, column, value);
        }

        public int ExecuteStroredProcedure(string stroredProcedureName, string name, string login)
        {
            var command = new SqlCommand
            { 
                 CommandType = CommandType.StoredProcedure,
                 CommandText = stroredProcedureName,
                 Connection = connector.GetConnection()
            };

            // передача параметров в хранимую процедуру
            command.Parameters.Add(new SqlParameter("@Name", name));
            command.Parameters.Add(new SqlParameter("@Login", login));

            return command.ExecuteNonQuery();
        }
    }
}
