using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKVGU.Models
{
    public class SubjectSemesterTotal
    {
        public int id { get; set; }
        public int GroupId { get; set; }
        public int SemesterId { get; set; }
        public string Subject { get; set; }
        public bool IsPractice { get; set; }
        public string Teacher { get; set; }
        public float Amount { get; set; }
    }
}