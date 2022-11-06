using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Dtos
{
    public class CollaboratorViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string Role { get; set; }
    }
}
