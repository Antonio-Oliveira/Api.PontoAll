using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Models.Dtos
{
    public class UserPointViewModel
    {
        public string Overtime { get; set; }

        public List<PointViewModel> Points { get; set; }
    }
}
