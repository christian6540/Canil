using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Canil.Models
{
    public class ConnectionDb
    {
        public string ConnectionString { get; set; }
        public ConnectionDb(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        //private MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(ConnectionString);
        //}
    }
}
