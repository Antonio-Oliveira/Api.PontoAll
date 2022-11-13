using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Points
{
    public class Point
    {
        [Required]
        public Guid PointId { get; set; }

        [Required]
        public string UserPhotograph { get; set; }

        [Required]
        public DateTime DatePoint { get; set; }

        [Required]
        public TypePointEnum TypePoint { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public Guid AddressPointId { get; set; }

        public virtual AddressPoint AddressPoint { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
