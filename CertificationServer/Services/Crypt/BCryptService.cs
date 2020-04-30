using CertificationServer.Models;
using CertificationServer.Models.Query;
using CertificationServer.Services.RDB;
using CertificationServer.Services.RDB.Query.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Services.Crypt
{
    public class BCryptService
    {
        public const string TESTKEY = "123abc";
        public static (ReturnCertEntity data, bool err) Regist(RegistEntity data, AppSettings settings)
        {
            try
            {
                data.Password = BCrypt.Net.BCrypt.HashPassword(data.Password, workFactor: 13, enhancedEntropy: true);
                Console.WriteLine($"hash " + data.ID + ": {data.Password}");
            }
            catch (Exception)
            {
                return (null, false);
            }
            return (new ReturnCertEntity(), true);
        }
        public static (ReturnCertEntity data, bool err) Verify(LoginEntity data, AppSettings settings)
        {
            //PostgresService.ExecuteAsync(new LoginQuery(), data, settings.Postgres).Result as ReturnCertEntity;
            data.Password = BCrypt.Net.BCrypt.HashPassword(data.Password, workFactor: 13, enhancedEntropy: true);
            Console.WriteLine($"hash " + data.ID + ": {data.Password}");
            var isVerified = BCrypt.Net.BCrypt.Verify(data.Password, TESTKEY, enhancedEntropy: true);
            Console.WriteLine($"same password: {isVerified}");
            return (new ReturnCertEntity(), isVerified);
        }
    }
}
