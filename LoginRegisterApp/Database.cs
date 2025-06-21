using System;
using System.Data.SQLite;
using System.Net.NetworkInformation;
using System.Security.Policy;

namespace LoginRegisterApp
{
    public static class Database
    {

        private static readonly string connectionString = "Data Source=users.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
