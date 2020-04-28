using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Models
{
    public class AppSettings
    {
        public Postgres Postgres { get; set; }
    }

    public class Postgres
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string UserId { get; set; }
        public string DatabaseName { get; set; }
        public string Password { get; set; }
    }
}
