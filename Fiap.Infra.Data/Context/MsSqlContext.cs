using Microsoft.Extensions.Options;
using Fiap.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Context
{
    public class MsSqlContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public MsSqlContext()
        {
            Connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=stone;Trusted_Connection=True;MultipleActiveResultSets=true");
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
