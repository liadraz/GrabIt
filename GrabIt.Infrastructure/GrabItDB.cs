using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace GrabIt.Infrastructure
{
    public class GrabItDB
    {
        private MySqlConnection connectionDb;

        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        private GrabItDB()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "localhost";
            port = "3306";
            database = "grabitdb";
            uid = "root";
            password = "password";

            string connString = $"server={server};" +
                                $"user={uid};" +
                                $"database={database};" +
                                $"port={port};" +
                                $"password={password}";

            connectionDb = new MySqlConnection(connString);
        }

        private bool OpenConnection()
        {
            try
            {
                connectionDb.Open();
                LogError("Connected to DB");

                return true;
            }
            catch (MySqlException ex) when (ex.Number == 0)
            {
                LogError("Cannot connect to Server", ex);
            }
            catch (MySqlException ex) when (ex.Number == 1045)
            {
                LogError("Invalid username/password. Please try again", ex);
            }
            catch (Exception ex)
            {
                LogError("An unexpected error occurred while connecting to the database.", ex);
            }

            return false;
        }

        private bool CloseConnection()
        {
            try
            {
                connectionDb.Close();
                LogError("Disconnected from DB");
                
                return true;
            }
            catch (MySqlException ex)
            {
                LogError("An error occurred while closing the connection.", ex);
            }
            catch (Exception ex)
            {
                LogError("An unexpected error occurred while closing the connection.", ex);
            }

            return false;
        }

        private void LogError(string message, Exception ex = null)
        {
            Console.WriteLine($"{message}\nError: {ex.Message}");

            string logFilePath = "error_log.txt";
            File.AppendAllText(logFilePath, $"{DateTime.Now} - {message} - {ex?.Message}{Environment.NewLine}");
        }
    }
}
