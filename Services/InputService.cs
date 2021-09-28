using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKVGU.Models;
using OKVGU.Repositories;

namespace OKVGU.Services
{

    public class InputService : IInputService
    {
        private IInputRepository inputRepository;
        public InputService (IInputRepository inputRepository)
        {
            this.inputRepository = inputRepository;
        }
        public List<Teacher> GetTeachers()
        {
            return inputRepository.GetTeachers();
        }
        public Teacher GetTeacher(int id)
        {
            return inputRepository.GetTeacher(id);
        }

        public List<Group> GetGroups()
        {
            return inputRepository.GetGroups();
        }
        public Group GetGroup(int id)
        {
            return inputRepository.GetGroup(id);
        }
        public List<GroupTotal> GetGroupTotals()
        {
            List<GroupTotal> groupsTotal = new List<GroupTotal>();
            List<Group> groups = inputRepository.GetGroups();
            List<Specialty> specialties = inputRepository.GetSpecialties();
            foreach (Group gr in groups)
            {
                GroupTotal groupTotal = new GroupTotal
                {
                    id = gr.id,
                    Title = gr.Title,
                    Course = gr.Course,
                    Specialty = specialties.Find(s => s.id == gr.SpecialtyId).Title
                };
                groupsTotal.Add(groupTotal);
            }
            return groupsTotal;
        }
        public bool AddGroup(Group group)
        {
            return inputRepository.AddGroup(group);
        }
        public bool EditGroup(Group group)
        {
            return inputRepository.EditGroup(group);
        }
        public List<Specialty> GetSpecialties()
        {
            return inputRepository.GetSpecialties();
        }
        public Specialty GetSpecialty(int id)
        {
            return inputRepository.GetSpecialty(id);
        }
        public bool EditSpecialty(Specialty specialty)
        {
            return inputRepository.EditSpecialty(specialty);
        }
        public bool AddSpecialty(Specialty spec)
        {
            return inputRepository.AddSpecialty(spec);
        }
        public List<Subject> GetSubjects()
        {
            return inputRepository.GetSubjects();
        }
        public Subject GetSubject(int id)
        {
            return inputRepository.GetSubject(id);
        }
        public bool AddSubject(Subject subject)
        {
            return inputRepository.AddSubject(subject);
        }
        public bool EditSubject(Subject subject)
        {
            return inputRepository.EditSubject(subject);
        }
        public bool AddTeacher(Teacher teacher)
        {
            return inputRepository.AddTeacher(teacher);
        }
        public bool EditTeacher(Teacher teacher)
        {
            return inputRepository.EditTeacher(teacher);
        }
        public bool DropTeacher(int id)
        {
            return inputRepository.DropTeacher(id);
        }
        public bool DropGroup(int id)
        {
            return inputRepository.DropGroup(id);
        }
        public bool DropSpecialty(int id)
        {
            return inputRepository.DropSpecialty(id);
        }
        public bool DropSubject(int id)
        {
            return inputRepository.DropSubject(id);
        }
        public List<SimpleGroup> GetSimpleGroups()
        {
            List<SimpleGroup> simpleGroups = new List<SimpleGroup>();
            foreach(Group gr in inputRepository.GetGroups())
            {
                SimpleGroup simpleGroup = new SimpleGroup
                {
                    id = gr.id,
                    Title = gr.Title
                };
                simpleGroups.Add(simpleGroup);
            }
            return simpleGroups;
        }
        public List<Semester> GetSemesters()
        {
            return inputRepository.GetSemesters();
        }
        public List<SubjectSemesterTotal> GetSubjectSemesterTotals()
        {
            return inputRepository.GetSubjectSemesterTotals();
        }
        public List<SubjectSemesterTotal> GetSubSemTotalsFor(int GroupId, int SemesterId)
        {
            return inputRepository.GetSubjectSemesterTotals()
                .Where(sst => sst.GroupId == GroupId && sst.SemesterId == SemesterId)
                .ToList<SubjectSemesterTotal>();
        }
        public SubjectSemester GetSubjectSemester(int id)
        {
            return inputRepository.GetSubjectSemester(id);
        }

        public bool AddSubjectSemester(SubjectSemester subjectSemester)
        {
            return inputRepository.AddSubjectSemester(subjectSemester);
        }

        public bool EditSubjectSemester(SubjectSemester subjectSemester)
        {
            return inputRepository.EditSubjectSemester(subjectSemester);
        }

        public bool DropSubjectSemester(int id)
        {
            return inputRepository.DropSubjectSemester(id);
        }

        public bool AddSemester(Semester semester)
        {
            return inputRepository.AddSemester(semester);
        }

        public bool EditSemester(Semester semester)
        {
            return inputRepository.EditSemester(semester);
        }

        public bool DropSemester(int id)
        {
            return inputRepository.DropSemester(id);
        }

        public Semester GetSemester(int id)
        {
            return inputRepository.GetSemester(id);
        }
        public List<SemesterTotal> GetSemesterTotals()
        {
            List<Semester> semesters = inputRepository.GetSemesters();
            List<SemesterTotal> semesterTotals = new List<SemesterTotal>();
            foreach (Semester semester in semesters)
            {
                SemesterTotal semesterTotal = new SemesterTotal
                {
                    id = semester.id,
                    Title = semester.Year + " №" + semester.Number
                };
                semesterTotals.Add(semesterTotal);
            }
            return semesterTotals;
        }

        public List<TeacherTotal> GetTeacherTotals()
        {
            List<Teacher> teachers = inputRepository.GetTeachers();
            List<TeacherTotal> teacherTotals = new List<TeacherTotal>();
            foreach(Teacher teacher in teachers)
            {
                TeacherTotal teacherTotal = new TeacherTotal
                {
                    id = teacher.id,
                    Name = teacher.LastName + " " + teacher.FirstName + " " + teacher.Patronym
                };
                teacherTotals.Add(teacherTotal);
            }
            return teacherTotals;
        }

        public GroupSemester GetGroupSemester(int groupId, int semesterId)
        {
            return inputRepository.GetGroupSemester(groupId, semesterId);
        }

        public bool AddGroupSemester(GroupSemester groupSemester)
        {
            return inputRepository.AddGroupSemester(groupSemester);
        }

        public bool EditGroupSemester(GroupSemester groupSemester)
        {
            return inputRepository.EditGroupSemester(groupSemester);
        }

        public GroupSemester GetGroupSemester(int id)
        {
            return inputRepository.GetGroupSemester(id);
        }
    }
}