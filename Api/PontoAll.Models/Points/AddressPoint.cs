using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Points
{
    public class AddressPoint 
    {
        [Required]
        public Guid AddressPointId { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string Number { get; set; }

        public string Reference { get; set; }
    }
}
