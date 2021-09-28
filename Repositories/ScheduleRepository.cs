using OKVGU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKVGU.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        public List<Group> GetGroups()
        {
            using (OkContext ctx = new OkContext())
            {
                var groupsResult = ctx.Database.SqlQuery<Group>("SELECT * FROM Groups");
                List<Group> groups = new List<Group>();
                foreach (Group gr in groupsResult)
                {
                    groups.Add(gr);
                }
                return groups;
            }
        }
        public List<SubjectSemester> GetSubjectSemestersForGroup(Group group, Semester semester)
        {
            int id = group.id;
            using (OkContext ctx = new OkContext())
            {
                List<Subject> subjects = new List<Subject>();
                List<SubjectSemester> subjectSemesters = ctx.SubjectSemesters.
                    Where(ss => ss.GroupId == group.id && ss.SemesterId == semester.id).ToList<SubjectSemester>(); 
                return subjectSemesters;
            }
        }
        public List<int> GetGroupsId()
        {
            List<int> groupsId = new List<int>();
            using (OkContext ctx = new OkContext())
            {
                var _id = from g in ctx.Groups select g.id;
                foreach (var id in _id)
                {
                    groupsId.Add(id);
                }
                return groupsId;         
            }
        }
        public List<int> GetTeachersId()
        {
            List<int> teachersId = new List<int>();
            using (OkContext ctx = new OkContext())
            {
                var _id = from t in ctx.Teachers select t.id;
                foreach (var id in _id)
                {
                    teachersId.Add(id);
                }
            }
            return teachersId;
        }
        public int GetNumberOfWeeks(Group group, Semester semester)
        {
            using (OkContext ctx = new OkContext())
            {
                int numberOfWeeks = ctx.GroupSemesters.FirstOrDefault(gs => gs.GroupId == group.id && gs.SemesterId == semester.id).NumberOfWeeks;
                return numberOfWeeks;
            }
        }

        public Subject GetSubject(int id)
        {
            using (OkContext ctx = new OkContext())
            {
                Subject subject = ctx.Subjects.Find(id);
                if (subject != null)
                    return subject;
                else
                    return null;
            }
        }
        public Teacher GetTeacher(int id)
        {
            using (OkContext ctx = new OkContext())
            {
                Teacher teacher = ctx.Teachers.Find(id);
                if (teacher != null)
                    return teacher;
                else
                    return null;
            }
        }
        public Semester GetSemester(int id)
        {
            using (OkContext ctx = new OkContext())
            {
                Semester semester = ctx.Semesters.Find(id);
                if (semester != null)
                    return semester;
                else
                    return null;
            }
        }

        public List<SubjectSemester> GetSubSemPracticeForGroup(Group group, Semester semester)
        {
            using (OkContext ctx = new OkContext())
            {
                var SubjectSemesters = ctx.SubjectSemesters.
                    Where(ss => ss.GroupId == group.id && ss.SemesterId == semester.id)
                    .Join(ctx.Subjects.Where(sub => sub.IsPractice == true),
                    subSem => subSem.SubjectId,
                    sub => sub.id,
                    (subSem, sub) => subSem
                    /*{
                        id = subSem.id,
                        SubjectId = subSem.SubjectId,
                        TeacherId = subSem.TeacherId,
                        GroupId = subSem.GroupId,
                        SemesterId = subSem.SemesterId,
                        Amount = subSem.Amount
                    }*/);
                return SubjectSemesters.ToList<SubjectSemester>();
            }
        }
    }
}