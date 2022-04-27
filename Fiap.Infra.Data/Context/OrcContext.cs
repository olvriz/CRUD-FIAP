using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Context
{
    public class OrcContext : IDisposable
    {
        public OracleConnection Connection { get; set; }

        public OrcContext()
        {
            string connectionString = Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING") ?? string.Empty;
            Connection = new OracleConnection(connectionString);
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
