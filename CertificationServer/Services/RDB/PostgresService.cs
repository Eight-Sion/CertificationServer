using CertificationServer.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Services.RDB
{
    public class PostgresService
    {
        public static async Task<IPostgresEntity> ExecuteAsync(IPostgresQuery service, IPostgresEntity queryData, Postgres setting)
        {
            IPostgresEntity result;
            using (NpgsqlConnection conn = new NpgsqlConnection(
                "Server=" + setting.Host +
                ";Port=" + setting.Port +
                ";User ID=" + setting.UserId +
                ";Database=" + setting.DatabaseName +
                ";Password=" + setting.Password +
                ";Enlist=true"))
            {
                //PostgreSQLへ接続
                await conn.OpenAsync();
                result = service.QueryStart(conn, queryData);
                await conn.CloseAsync();
            }
            return result;
        }
    }
    public interface IPostgresQuery
    {
        public IPostgresEntity QueryStart(NpgsqlConnection conn, IPostgresEntity source);
    }
    public interface IPostgresEntity
    {
        public void CopyTo(IPostgresEntity source);
        public void Clear();
    }
}
