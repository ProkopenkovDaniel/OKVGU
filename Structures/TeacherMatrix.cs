using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace OKVGU.Structures
{
    public class TeacherMatrix
    {
        private int[,,] matrix;
        private Dictionary<int, int> teachers;
        public TeacherMatrix(List<int> TeachersId)
        {
            matrix = new int[TeachersId.Count(), 6, 10];
            teachers = new Dictionary<int, int>();
            int i = 0;
            foreach (int id in TeachersId)
            {
                teachers.Add(id, i);
                i++;
                Debug.WriteLine(i + " " + id);
            }
        }
        public bool Add(int teacherId, int day, int lesson, int value)
        {
            try
            {
                if (value == 0)
                { return false; }
                else { 
                    if (matrix[teachers[teacherId], day, lesson] != 0)
                    { return false; } 
                    else 
                    { 
                        matrix[teachers[teacherId], day, lesson] = value;
                        Debug.WriteLine("Add: " + teacherId + " " + day + " " + lesson + " = " + matrix[teachers[teacherId], day, lesson]);
                    }
                }
                return true;
            }
            catch { return false; }
        }
        public void Remove(int teacherId, int day, int lesson)
        {
            try
            {
                matrix[teachers[teacherId], day, lesson] = 0;
                Debug.WriteLine("Remove: " + teacherId + " " + day + " " + lesson + " = " + matrix[teachers[teacherId], day, lesson]);
            }
            catch { }

        }
        public void Clear()
        {
            Array.Clear(matrix, 0, matrix.Length);
        }
    }
}