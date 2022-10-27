using Microsoft.AspNetCore.Identity;
using PontoAll.Models.Companys;
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

        public Guid AddressId { get; set; }

        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Address Address { get; set; }
    }
}
