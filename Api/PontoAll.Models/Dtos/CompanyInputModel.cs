using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Dtos
{
    public class CompanyInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} está inválido")]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} está inválido")]
        public string FantasyName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^\d{2}\.?\d{3}\.?\d{3}\/?\d{4}\-?\d{2}$")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} está inválido")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[RegularExpression(@"^\(?[1-9]{2}\)?\s?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string  Email { get; set; }
    }
}
