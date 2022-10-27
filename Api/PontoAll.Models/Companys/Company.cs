using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Companys
{
    public class Company
    {
        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public string CorporateName { get; set; }

        [Required]
        public string FantasyName { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
