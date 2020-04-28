using CertificationServer.Services.RDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Models.Query
{
    public class LoginEntity : IPostgresEntity
    {
        public string ID { get; set; }
        public string Password { get; set; }

        public void Clear()
        {
            ID = string.Empty;
            Password = string.Empty;
        }

        public void CopyTo(IPostgresEntity source)
        {
            (source as LoginEntity).ID = ID;
            (source as LoginEntity).Password = Password;
        }
    }
}
