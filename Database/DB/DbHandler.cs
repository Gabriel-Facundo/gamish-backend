using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Database.DB
{
    public class DbHandler : IDisposable
    {
        public IDbConnection Connection { get; }

        public DbHandler(IConfiguration configuration)
        {
            Connection = new MySqlConnection(configuration["ConnectionString"]);
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
