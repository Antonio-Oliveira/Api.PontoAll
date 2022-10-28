using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.User
{
    public class CollaboratorUser : ApplicationUser
    {
        [Required]
        public int CPF { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        public virtual Address Address { get; set; }

    }
}
