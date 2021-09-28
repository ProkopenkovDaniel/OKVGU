using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OKVGU.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronym { get; set; }
        public bool IsAdm { get; set; }
        public bool IsSocWorker { get; set; }
        public int HoursPerYear { get; set; }

        public List<TeacherSubject> TeacherSubjects { get; set; }
        public List<SubjectSemester> SubjectSemesters { get; set; }
    }
}
