using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKVGU.Models;

namespace OKVGU.Repositories
{
    public interface IInputRepository
    {
        List<Teacher> GetTeachers();
        List<Group> GetGroups();
        List<Subject> GetSubjects();
        List<Specialty> GetSpecialties();
        List<Semester> GetSemesters();
        List<SubjectSemester> GetSubjectSemesters();
        List<SubjectSemesterTotal> GetSubjectSemesterTotals();
        Teacher GetTeacher(int id);
        Group GetGroup(int id);
        Specialty GetSpecialty(int id);
        Subject GetSubject(int id);
        SubjectSemester GetSubjectSemester(int id);
        Semester GetSemester(int id);
        GroupSemester GetGroupSemester(int groupId, int semesterId);
        GroupSemester GetGroupSemester(int id);
        bool AddTeacher(Teacher teacher);
        bool AddGroup(Group group);
        bool AddSpecialty(Specialty spec);
        bool AddSubject(Subject subject);
        bool AddSubjectSemester(SubjectSemester subjectSemester);
        bool AddSemester(Semester semester);
        bool EditTeacher(Teacher teacher);
        bool EditGroup(Group group);
        bool EditSpecialty(Specialty specialty);
        bool EditSubject(Subject subject);
        bool EditSemester(Semester semester);
        bool EditSubjectSemester(SubjectSemester subjectSemester);
        bool DropTeacher(int id);
        bool DropGroup(int id);
        bool DropSubject(int id);
        bool DropSpecialty(int id);
        bool DropSemester(int id);
        bool DropSubjectSemester(int id);
        bool AddGroupSemester(GroupSemester groupSemester);
        bool EditGroupSemester(GroupSemester groupSemester);

    }
}
