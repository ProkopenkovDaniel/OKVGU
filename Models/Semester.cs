using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OKVGU.Models
{
    public class Semester
    {
        public int id { get; set; }
        [Required (ErrorMessage = "Введите учебный год")]
        public string Year { get; set; }
        [Required (ErrorMessage = "Недопустимый номер семестра")]
        [Range(1, 2, ErrorMessage = "Недопустимый номер семестра")]
        public int Number { get; set; }
        public List<SubjectSemester> SubjectSemesters { get; set; }
        public List<GroupSemester> GroupSemesters { get; set; }

    }
}
