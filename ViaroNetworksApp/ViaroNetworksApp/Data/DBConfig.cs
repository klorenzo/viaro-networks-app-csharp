using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ViaroNetworksApp.Data
{
    public class DBConfig
    {
        private static DBConfig Instance;

        private static readonly string ConnectionString = "Data Source=localhost\\SQLEXPRESS;" +
            "Initial Catalog=viaronetworksapp;Integrated Security=true;";

        private SqlConnection Connection;

        private DBConfig()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static DBConfig GetInstance()
        {
            if(Instance == null)
            {
                Instance = new DBConfig();
            }
            return Instance;
        }

        public SqlConnection GetConnection()
        {
            return Connection;
        }
    }
}