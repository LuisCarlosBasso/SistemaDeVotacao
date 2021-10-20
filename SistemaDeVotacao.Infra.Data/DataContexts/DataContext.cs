using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaDeVotacao.Infra.Settings;

namespace SistemaDeVotacao.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public MySqlConnection MySqlConnection { get; set; }

        public DataContext(AppSettings appSettings)
        {
            try
            {
                MySqlConnection = new MySqlConnection(appSettings.ConnectionString);
                MySqlConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (MySqlConnection.State != ConnectionState.Closed) MySqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}