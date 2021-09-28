using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKVGU.Models;
using OKVGU.Repositories;
using OKVGU.Structures;

using System.Diagnostics;

namespace OKVGU.Services
{
    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }
        public void Generate(int semesterId)
        {
            List<Group> groups = scheduleRepository.GetGroups();
            PositionMatrix positions = new PositionMatrix(scheduleRepository.GetGroupsId());
            TeacherMatrix teachers = new TeacherMatrix(scheduleRepository.GetTeachersId());
            Semester semester = scheduleRepository.GetSemester(semesterId);
            foreach(Group group in groups)
            {
                GenerateScheduleForGroup(group, semester, out positions, out teachers); 
            }
            
        }

        public List<Group> GetGroups()
        {
            return scheduleRepository.GetGroups();
        }

        private void GenerateScheduleForGroup(Group group, Semester semester, out PositionMatrix positions, out TeacherMatrix teachers)
        {
            PriorityQueue<int, Subject> subjects = GetSubjectsQueue(group, semester);
            //распределение расписания для группы
            while(subjects.Count!=0) //пока не пройдены все предметы
            {

            }
            positions = new PositionMatrix(new List<int>());
            teachers = new TeacherMatrix(new List<int>());
        }
        
        private PriorityQueue<int, Subject> GetSubjectsQueue(Group group,  Semester semester)
        {
            PriorityQueue<int, Subject> queue = new PriorityQueue<int, Subject>();
            List<SubjectSemester> subjects = scheduleRepository.GetSubjectSemestersForGroup(group, semester);
            List<SubjectSemester> practices = scheduleRepository.GetSubSemPracticeForGroup(group, semester);
            subjects = subjects.Except(practices).ToList<SubjectSemester>();
            List<SubjectSemester> subjectPractices = new List<SubjectSemester>();
            List<SubjectSemester> practicesBuf = new List<SubjectSemester>();
            foreach (SubjectSemester subSem in practices)
            {
                practicesBuf.Add((SubjectSemester)subSem.Clone());
            }
            foreach(SubjectSemester subSem in practices)
            {
                practicesBuf.Remove(practicesBuf.Find(pb=>pb.id == subSem.id));
                List<SubjectSemester> secondSubSem = practicesBuf
                    .Where(p => p.SubjectId == subSem.SubjectId)
                    .ToList<SubjectSemester>();
                if (secondSubSem.Count() != 0)
                {
                    SubjectSemester secondSubSemBuf = secondSubSem[0];
                    SubjectSemester buf = subSem;
                    buf.SecondTeacherId = secondSubSemBuf.TeacherId;
                    subjectPractices.Add(buf);
                    practicesBuf.Remove(secondSubSemBuf);
                }
            }
            subjects = subjects.Union(subjectPractices).ToList<SubjectSemester>();
            int numberOfWeeks = scheduleRepository.GetNumberOfWeeks(group, semester);
            foreach (SubjectSemester subSem in subjects)
            {
                int countOfSubjects =(int)Math.Ceiling(subSem.Amount / numberOfWeeks);
                List<SubjectPair> pairs = new List<SubjectPair>();
                List<SubjectSemester> subjectSemesters = new List<SubjectSemester>();
                for(int i = 0; i<countOfSubjects; i++)
                {
                    subjectSemesters.Add(subSem);
                }
                while (countOfSubjects != 0)
                {
                    SubjectPair element = new SubjectPair();
                    
                }
                int priority = 2;
                if (scheduleRepository.GetSubject(subSem.SubjectId).Title == "ФКиЗ")
                {
                    priority = 1;
                }
                else
                {
                    if (scheduleRepository.GetTeacher(subSem.TeacherId).IsAdm)
                    {
                        priority = 3;
                    }
                }
                for (int i = 1; i <= Math.Ceiling(subSem.Amount / numberOfWeeks); i++)
                {
                    queue.Enqueue(priority, scheduleRepository.GetSubject(subSem.id));
                    Debug.WriteLine(scheduleRepository.GetSubject(subSem.SubjectId).Title + " " + priority);
                }
                //распределяется без учёта пар, просто подряд.
            }
            return queue;
        }

    }
}