using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Token
{
    public class TokenSettings
    {
        public string Secret { get; set; }

        public int Expires { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
