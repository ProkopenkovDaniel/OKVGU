using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OKVGU.Models;

namespace OKVGU.Structures
{
    public class SubjectPair
    {
        public SubjectSemester FirstSubject { get; set; }
        public SubjectSemester SecondSubject { get; set; }

        public SubjectPair(SubjectSemester firstSubject, SubjectSemester secondSubject)
        {
            FirstSubject = firstSubject;
            SecondSubject = secondSubject;
        }
        public SubjectPair(SubjectSemester firstSubject)
        {
            FirstSubject = firstSubject;
            SecondSubject = null;
        }
        public SubjectPair()
        {}

        public void Add(SubjectSemester subjectSemester)
        {
            if (FirstSubject == null)
            {
                FirstSubject = subjectSemester;
            } else 
                if(SecondSubject == null)
            {
                SecondSubject = subjectSemester;
            }
        }
        public void AddWithCount(SubjectSemester subjectSemester, ref int count)
        {
            if (FirstSubject == null)
            {
                FirstSubject = subjectSemester;
                count -= 1;
            }
            else
                if (SecondSubject == null)
            {
                SecondSubject = subjectSemester;
                count -= 1;
            }
        }
    }
}