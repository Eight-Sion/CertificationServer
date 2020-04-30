using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertificationServer.Models.Crypt
{
    public class SaltEntity
    {
        public string FirstKey { get; set; }
        public string SecondKey { get; set; }
        public string ThirdKey { get; set; }
        public override string ToString()
            => FirstKey + SecondKey + ThirdKey;
    }
}
