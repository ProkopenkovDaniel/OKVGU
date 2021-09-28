using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKVGU.Models;

namespace OKVGU.Repositories
{
    public interface IScheduleRepository
    {
        List<Group> GetGroups();
        List<SubjectSemester> GetSubjectSemestersForGroup(Group group, Semester semester);
        List<int> GetGroupsId();
        List<int> GetTeachersId();
        int GetNumberOfWeeks(Group group, Semester semester);
        Subject GetSubject(int id);
        Teacher GetTeacher(int id);
        Semester GetSemester(int id);
        List<SubjectSemester> GetSubSemPracticeForGroup(Group group, Semester semester);

    }
}
