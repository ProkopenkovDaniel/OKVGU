using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKVGU.Models
{
    public class TeacherSubject
    {
        public int id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
