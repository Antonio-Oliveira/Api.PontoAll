using Microsoft.AspNetCore.Http;
using PontoAll.Models.Points;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Dtos
{
    public class PointViewModel
    {
        public DateTime DatePoint { get; set; }

        public string TypePoint { get; set; }

        public string UserPhotograph { get; set; }
    }
}
