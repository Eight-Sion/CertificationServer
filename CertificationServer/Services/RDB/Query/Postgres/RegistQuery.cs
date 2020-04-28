using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Services.RDB.Query.Postgres
{
    public class RegistQuery : IPostgresQuery
    {
        public IPostgresEntity QueryStart(NpgsqlConnection conn, IPostgresEntity source)
        {
            throw new NotImplementedException();
        }
    }
}
