using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKVGU.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace OKVGU.Repositories
{
   
    public class InputRepository : IInputRepository
    {
        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            using (OkContext ctx = new OkContext())
            {
                ctx.Teachers.Load();
                teachers = ctx.Teachers.OrderBy(t=>t.LastName).ToList<Teacher>();
            }
            return teachers;
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
        public bool AddTeacher(Teacher teacher)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.Teachers.Add(teacher);
                    ctx.SaveChanges();
                }
                catch { return false; }
                return true;
            }
        }
        public bool EditTeacher(Teacher teacher)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.Teachers.Load();
                    Teacher editedTeacher = ctx.Teachers.Find(teacher.id);
                    editedTeacher.FirstName = teacher.FirstName;
                    editedTeacher.LastName = teacher.LastName;
                    editedTeacher.Patronym = teacher.Patronym;
                    editedTeacher.IsAdm = teacher.IsAdm;
                    editedTeacher.IsSocWorker = teacher.IsSocWorker;
                    editedTeacher.HoursPerYear = teacher.HoursPerYear;
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }
        public List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();
            using (OkContext ctx = new OkContext())
            {
                ctx.Groups.Load();
                groups = ctx.Groups.ToList<Group>();
            }
            return groups;
        }
        public Group GetGroup(int id)
        {
            using (OkContext ctx = new OkContext())
            {
                Group group = ctx.Groups.Find(id);
                if (group != null)
                    return group;
                else
                    return null;
            }
        }
        public bool EditGroup(Group group)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    SqlParameter title = new SqlParameter("@title", group.Title);
                    SqlParameter course = new SqlParameter("@course", group.Course);
                    SqlParameter specialtyId = new SqlParameter("@specId", group.SpecialtyId);
                    SqlParameter id = new SqlParameter("@id", group.id);
                    parameters.Add(title);
                    parameters.Add(course);
                    parameters.Add(specialtyId);
                    parameters.Add(id);
                    int updatedNumber = ctx.Database.ExecuteSqlCommand(
                        "UPDATE Groups " +
                        "SET Title = @title, " +
                        "Course = @course, " +
                        "SpecialtyId = @specId " +
                        "WHERE id = @id", parameters.ToArray());
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }
        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            using (OkContext ctx = new OkContext())
            {
                ctx.Subjects.Load();
                subjects = ctx.Subjects.OrderBy(s => s.Title).ToList<Subject>();
            }
            return subjects;
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
        public bool EditSubject(Subject subject)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    //SqlParameter title = new SqlParameter("@title", subject.Title);
                    //SqlParameter isPractice = new SqlParameter("@isPractice", subject.IsPractice);
                    //SqlParameter id = new SqlParameter("@id", subject.id);
                    //int updatedNumber = ctx.Database.ExecuteSqlCommand(
                    //    "UPDATE Subjects" +
                    //    "SET Title = @title," +
                    //    "IsPractice = @isPractice" +
                    //    "WHERE id = @id", new { title, isPractice, id });
                    ctx.Subjects.Load();
                    Subject editedSubject = ctx.Subjects.Find(subject.id);
                    editedSubject.Title = subject.Title;
                    editedSubject.IsPractice = subject.IsPractice;
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }
        public bool AddSubject(Subject subject)
        {
            using (OkContext ctx = new OkContext()) {

                try
                {
                    ctx.Subjects.Add(subject);
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }
        public List<Specialty> GetSpecialties()
        {
            List<Specialty> specialties = new List<Specialty>();
            using(OkContext ctx = new OkContext())
            {
                ctx.Specialties.Load();
                specialties = ctx.Specialties.ToList<Specialty>();
            }
            return specialties;
        }
        public Specialty GetSpecialty(int id)
        {
            using (OkContext ctx = new OkContext())
            {
                Specialty specialty = ctx.Specialties.Find(id);
                if (specialty != null)
                    return specialty;
                else
                    return null;
            }
        }
        public bool EditSpecialty(Specialty specialty)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    //SqlParameter title = new SqlParameter("@title", specialty.Title);
                    //SqlParameter isPedSpec = new SqlParameter("@isPedSpec", specialty.IsPedSpec);
                    //SqlParameter id = new SqlParameter("@id", specialty.id);
                    //int updatedNumber = ctx.Database.ExecuteSqlCommand(
                    //    "UPDATE Specialties" +
                    //    "SET Title = @title," +
                    //    "IsPedSpec = @isPedSpec" +
                    //    "WHERE id = @id", new { title, isPedSpec, id });
                    ctx.Specialties.Load();
                    Specialty editedSpecialty = ctx.Specialties.Find(specialty.id);
                    editedSpecialty.Title = specialty.Title;
                    editedSpecialty.IsPedSpec = specialty.IsPedSpec;
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }
        public bool AddSpecialty(Specialty spec)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    if (ctx.Specialties.Where(s => s.Title == spec.Title).Count() != 0)
                        throw new Exception();
                    ctx.Specialties.Add(spec);
                    ctx.SaveChanges();
                }
                catch { return false; }
                return true;
            }
        }
        public List<GroupTotal> GetGroupTotals()
        {
            List<GroupTotal> groups = new List<GroupTotal>();
            using (OkContext ctx = new OkContext())
            {
                var _groups = ctx.Groups.Join(ctx.Specialties,
                    g => g.SpecialtyId,
                    s => s.id,
                    (g, s) => new
                    {
                        id = g.id,
                        Title = g.Title,
                        Course = g.Course,
                        Specialty = s.Title
                    });
                foreach (var gr in _groups)
                {
                    GroupTotal group = new 
                        GroupTotal{ 
                        id = gr.id,
                        Title = gr.Title,
                        Course = gr.Course,
                        Specialty = gr.Specialty
                    };
                    groups.Add(group);
                }
            }
            return groups;
        }
        public bool AddGroup(Group group)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.Groups.Add(group);
                    ctx.SaveChanges();
                }
                catch { return false; }
                return true;
            }
        }
        public bool DropTeacher(int id)
        {
            try
            {
                using (OkContext ctx = new OkContext())
                {
                    Teacher teacher = ctx.Teachers.Find(id);
                    if (teacher != null)
                    {
                        ctx.Teachers.Remove(teacher);
                        ctx.SaveChanges();
                    }
                    else throw new Exception("Элемент удаления отсутсвует");
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DropSpecialty(int id)
        {
            try
            {
                using (OkContext ctx = new OkContext())
                {
                    Specialty specialty = ctx.Specialties.Find(id);
                    if (specialty != null)
                    {
                        ctx.Specialties.Remove(specialty);
                        ctx.SaveChanges();
                    }
                    else throw new Exception("Элемент удаления отсутсвует");
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DropSubject(int id)
        {
            try
            {
                using (OkContext ctx = new OkContext())
                {
                    Subject subject = ctx.Subjects.Find(id);
                    if (subject != null)
                    {
                        //SqlParameter[] parameters = { new SqlParameter("@id", id) };
                        //int deletedNumber = ctx.Database.ExecuteSqlCommand(
                        //    "DELETE FROM Subjects" +
                        //    "WHERE id=@id", parameters);
                        ctx.Subjects.Remove(subject);
                        ctx.SaveChanges();
                    }
                    else throw new Exception("Элемент удаления отсутсвует");
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DropGroup(int id)
        {
            try
            {
                using (OkContext ctx = new OkContext())
                {
                    Group group = ctx.Groups.Find(id);
                    if (group != null)
                    {
                        //SqlParameter[] parameters = { new SqlParameter("@id", id) };
                        //int deletedNumber = ctx.Database.ExecuteSqlCommand(
                        //    "DELETE FROM Subjects" +
                        //    "WHERE id=@id", parameters);
                        ctx.Groups.Remove(group);
                        ctx.SaveChanges();
                    }
                    else throw new Exception("Элемент удаления отсутсвует");
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public List<Semester> GetSemesters()
        {
            List<Semester> semesters = new List<Semester>();
            using (OkContext ctx = new OkContext())
            {
                ctx.Semesters.Load();
                semesters = ctx.Semesters.ToList<Semester>();
            }
            return semesters;
        }
        public List<SubjectSemester> GetSubjectSemesters() 
        {
            List<SubjectSemester> subjectSemesters = new List<SubjectSemester>();
            using (OkContext ctx = new OkContext())
            {
                ctx.SubjectSemesters.Load();
                subjectSemesters = ctx.SubjectSemesters.ToList<SubjectSemester>();
            }
            return subjectSemesters;
        }
        public List<SubjectSemesterTotal> GetSubjectSemesterTotals()
        {
            List<SubjectSemesterTotal> sstList = new List<SubjectSemesterTotal>();
            try
            {
                using (OkContext ctx = new OkContext())
                {
                    var ssTotals = from ss in ctx.SubjectSemesters
                                   join t in ctx.Teachers on ss.TeacherId equals t.id
                                   join s in ctx.Subjects on ss.SubjectId equals s.id
                                   select new
                                   {
                                       id = ss.id,
                                       SemesterId = ss.SemesterId,
                                       GroupId = ss.GroupId,
                                       TeacherFirstName = t.FirstName,
                                       TeacherLastName = t.LastName,
                                       TeacherPatronym = t.Patronym,
                                       Subject = s.Title,
                                       IsPractice = s.IsPractice,
                                       Amount = ss.Amount
                                   };
                    foreach (var ssTotal in ssTotals)
                    {

                        SubjectSemesterTotal subjectSemesterTotal = new SubjectSemesterTotal
                        {
                            id = ssTotal.id,
                            SemesterId = ssTotal.SemesterId,
                            GroupId = ssTotal.GroupId,
                            Subject = ssTotal.IsPractice? ssTotal.Subject + " (ПР)": ssTotal.Subject,
                            IsPractice = ssTotal.IsPractice,
                            Teacher = ssTotal.TeacherLastName + " " + ssTotal.TeacherFirstName +" "+ ssTotal.TeacherPatronym,
                            Amount = ssTotal.Amount
                        };
                        sstList.Add(subjectSemesterTotal);
                    }
                }
            }
            catch
            {
                return new List<SubjectSemesterTotal>(); 
            }
            return sstList;
        }
        public SubjectSemester GetSubjectSemester(int id)
        {
            using (OkContext ctx = new OkContext())
            {
                SubjectSemester subSem = ctx.SubjectSemesters.Find(id);
                if (subSem != null)
                {
                    return subSem;
                }
                return null;
            }
        }

        public bool AddSubjectSemester(SubjectSemester subjectSemester)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.SubjectSemesters.Add(subjectSemester);
                    ctx.SaveChanges();
                }
                catch { return false; }
                return true;
            }
        }

        public bool EditSubjectSemester(SubjectSemester subjectSemester)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.SubjectSemesters.Load();
                    SubjectSemester eSubjectSemester = ctx.SubjectSemesters.Find(subjectSemester.id);
                    eSubjectSemester.GroupId = subjectSemester.GroupId;
                    eSubjectSemester.SemesterId = subjectSemester.SemesterId;
                    eSubjectSemester.SubjectId = subjectSemester.SubjectId;
                    eSubjectSemester.TeacherId = subjectSemester.TeacherId;
                    eSubjectSemester.Amount = subjectSemester.Amount;
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }

        public bool DropSubjectSemester(int id)
        {
            try
            {
                using (OkContext ctx = new OkContext())
                {
                    SubjectSemester subjectSemester = ctx.SubjectSemesters.Find(id);
                    if (subjectSemester != null)
                    {
                        ctx.SubjectSemesters.Remove(subjectSemester);
                        ctx.SaveChanges();
                    }
                    else throw new Exception("Элемент удаления отсутсвует");
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool AddSemester(Semester semester)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.Semesters.Add(semester);
                    ctx.SaveChanges();
                }
                catch { return false; }
                return true;
            }
        }

        public bool EditSemester(Semester semester)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.Semesters.Load();
                    Semester eSemester = ctx.Semesters.Find(semester.id);
                    eSemester.Year = semester.Year;
                    eSemester.Number = semester.Number;
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }

        public bool DropSemester(int id)
        {
            try
            {
                using (OkContext ctx = new OkContext())
                {
                    Semester semester = ctx.Semesters.Find(id);
                    if (semester != null)
                    {
                        ctx.Semesters.Remove(semester);
                        ctx.SaveChanges();
                    }
                    else throw new Exception("Элемент удаления отсутсвует");
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
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

        public GroupSemester GetGroupSemester(int groupId, int semesterId)
        {
            using (OkContext ctx = new OkContext())
            {
                GroupSemester groupSemester = ctx.GroupSemesters
                    .Where(gs => gs.GroupId == groupId && gs.SemesterId == semesterId)
                    .FirstOrDefault();
                return groupSemester;
            }
        }

        public bool AddGroupSemester(GroupSemester groupSemester)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    ctx.GroupSemesters.Add(groupSemester);
                    ctx.SaveChanges();
                }
                catch { return false; }
                return true;
            }
        }

        public bool EditGroupSemester(GroupSemester groupSemester)
        {
            using (OkContext ctx = new OkContext())
            {
                try
                {
                    GroupSemester editedGroupSem = ctx.GroupSemesters.Find(groupSemester.id);
                    editedGroupSem.NumberOfWeeks = groupSemester.NumberOfWeeks;
                    ctx.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
        }
        public GroupSemester GetGroupSemester(int id)
        {
            using (OkContext ctx = new OkContext())
            {
                GroupSemester groupSemester = ctx.GroupSemesters.Find(id);
                return groupSemester;
            }
        }
    }
}