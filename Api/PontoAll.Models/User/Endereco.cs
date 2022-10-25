using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.User
{
    public class Endereco
    {
        public string Country { get; set; }

        public string State { get; set; }

        public string CEP { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string Number { get; set; }

        public string Reference { get; set; }
    }
}
