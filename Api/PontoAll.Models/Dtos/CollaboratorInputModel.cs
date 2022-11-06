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
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} está inválido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\+)?([0-9]{2})?\s?\(?[1-9]{2}\)?\s?(?:[2-8]|9\s?[1-9])[0-9]{3}\-?[0-9]{4}$")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool IsManager { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public virtual AddressInputModel Address { get; set; }
    }
}
