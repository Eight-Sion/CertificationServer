using CertificationServer.Services.RDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Models.Query
{
    public class ReturnCertEntity : IPostgresEntity
    {
        public string PublicKey { get; set; }
        public string RefreshKey { get; set; }

        public void Clear()
        {
            PublicKey = string.Empty;
            RefreshKey = string.Empty;
        }

        public void CopyTo(IPostgresEntity source)
        {
            (source as ReturnCertEntity).PublicKey = PublicKey;
            (source as ReturnCertEntity).RefreshKey = RefreshKey;
        }
    }
}
