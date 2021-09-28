using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OKVGU.Models
{
    public class Group 
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Идентификатор пользователя не установлен")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Идентификатор пользователя не установлен")]
        public int Course { get; set; }
        public int SpecialtyId { get; set; }
        public List<SubjectSemester> SubjectSemesters { get; set; }
        public List<GroupSemester> GroupSemesters { get; set; }

    }
}
