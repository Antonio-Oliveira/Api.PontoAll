using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Dtos
{
    public class CollaboratorInputModel
    {
        [Required]
        public int CPF { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public virtual AddressInputModel Address { get; set; }
    }
}
