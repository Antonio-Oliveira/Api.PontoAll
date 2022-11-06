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
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public DateTime DatePoint { get; set; }

        [Required]
        public AddressInputModel Address { get; set; }

        [Required]
        public GeolocationInputModel Geolocation { get; set; }

    }
}
