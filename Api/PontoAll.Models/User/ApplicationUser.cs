using Microsoft.AspNetCore.Identity;
using PontoAll.Models.Companys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
