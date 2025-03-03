using System;
using System.Collections.Generic;
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

        private const string DEVICES = "devices";

        public GrabItDB()   // TODO convert to singleton
        {
            Initialize();
        }

        private void Initialize()
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
        private void LogError(string message, Exception ex = null)
        {
            Console.WriteLine($"{message}\nError: {ex.Message}");

            string logFilePath = "error_log.txt";
            File.AppendAllText(logFilePath, $"{DateTime.Now} - {message} - {ex?.Message}{Environment.NewLine}");

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

        public void Insert(string name, string type)
        {
            string query = $"INSERT INTO {DEVICES}(name, type, status) VALUES ({name},{type}, 'AVAILABLE')";

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connectionDb);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Update(int id)
        {
            string query = $"UPDATE {DEVICES} SET status = 'BUSY' WHERE device_id = {id}";

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                
                cmd.CommandText = query;
                cmd.Connection = connectionDb;
                cmd.ExecuteNonQuery();
                
                this.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            string query = $"DELETE FROM {DEVICES} WHERE device_id = {id}";

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connectionDb);
                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }

        }

        public List<string> Select()
        {
            return new List<string>();
        }

        public int Count()
        {
            return 0;
        }
    }
}
