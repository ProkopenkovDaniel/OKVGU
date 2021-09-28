using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace OKVGU.Structures
{
    public class PositionMatrix
    {
        private int [,,] matrix;
        private Dictionary<int, int> groups;
        public PositionMatrix(List<int> GroupsId)
        {
            matrix = new int[GroupsId.Count(), 6, 10];
            groups = new Dictionary<int, int>();
            int i = 0;
            foreach (int id in GroupsId)
            {
                groups.Add(id, i);
                i++;
                Debug.WriteLine(i + " " + id);
            }
        } 
        public void Add(int groupId, int day, int lesson, int value)
        {
            try
            {
                if (value != 0)
                {
                    matrix[groups[groupId], day, lesson] = value;
                    Debug.WriteLine("Add: " + groupId + " " + day + " " + lesson + " = " + matrix[groups[groupId], day, lesson]);
                }
            }
            catch { }
        }
        public void Remove (int groupId, int day, int lesson)
        {
            try
            {
                matrix[groups[groupId], day, lesson] = 0;
                Debug.WriteLine("Remove: " + groupId + " " + day + " " + lesson + " = " + matrix[groups[groupId], day, lesson]);
            }
            catch { }
            
        }
        public void Clear()
        {
            Array.Clear(matrix, 0, matrix.Length);
        }
    }
}