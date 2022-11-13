using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Dtos
{
    public class PointInputModel
    {
        public IFormFile UserPhotograph { get; set; }

        [Required]
        public AddressInputModel Address { get; set; }
    }
}
