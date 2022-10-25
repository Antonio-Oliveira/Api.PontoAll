using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.User
{
    public class ApplicationUser : IdentityUser
    {

        public int CPF { get; set; }

        public DateTime BirthDate { get; set; }

        public int EnderecoId { get; set; }

    }
}
