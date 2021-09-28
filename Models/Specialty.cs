using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OKVGU.Models
{
    public class Specialty
    {
        public int id { get; set; }
        public string Title { get; set; }
        public bool IsPedSpec { get; set; }

    }
}
