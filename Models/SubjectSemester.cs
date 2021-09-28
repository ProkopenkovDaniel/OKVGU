using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace OKVGU.Models
{
    public class SubjectSemester : ICloneable
    {
        public int id { get; set; }
        public int SubjectId { get; set; }
        public int GroupId { get; set; }
        public int SemesterId { get; set; }
        public int TeacherId { get; set; }
        [NotMapped]
        public int SecondTeacherId { get; set; }
        public float Amount { get; set; }

        public object Clone()
        {
            return new SubjectSemester { 
                id = id,
                SubjectId = SubjectId,
                GroupId = GroupId,
                SemesterId = SemesterId,
                TeacherId = TeacherId,
                SecondTeacherId = SecondTeacherId,
                Amount = Amount
            };
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is SubjectSemester))
            {
                throw new ArgumentException("obj is not an SubjectSemester");
            }
            var subSemObj = obj as SubjectSemester;
            if (subSemObj == null) return false;
            return this.id.Equals(subSemObj.id);
        }
    }
}
