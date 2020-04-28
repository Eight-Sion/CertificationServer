using CertificationServer.Services.RDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Models.Query
{
    public class RegistEntity : IPostgresEntity
    {
        public string ID { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }

        public void Clear()
        {
            ID = string.Empty;
            Password = string.Empty;
            Nickname = string.Empty;
            Nickname = string.Empty;
        }

        public void CopyTo(IPostgresEntity source)
        {
            (source as RegistEntity).ID = ID;
            (source as RegistEntity).Password = Password;
            (source as RegistEntity).Nickname = Nickname;
            (source as RegistEntity).PhoneNumber = PhoneNumber;
        }
    }
}
