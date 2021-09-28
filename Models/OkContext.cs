using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OKVGU.Models
{
    class OkContext :DbContext
    {
        public OkContext()
            : base("DbConnection")
        {}

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        //public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<SubjectSemester> SubjectSemesters { get; set; }
        public DbSet<GroupSemester> GroupSemesters { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScheduleInstance> ScheduleInstances { get; set; } 
    }
}
