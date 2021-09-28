using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKVGU.Models
{
    public class GroupSemester
    {
        public int id { get; set; }
        public int GroupId { get; set; }
        public int SemesterId { get; set; }
        public int NumberOfWeeks { get; set; }
    }
}
