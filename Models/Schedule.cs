using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OKVGU.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public int Day { get; set; }
        public int Week { get; set; }
        public int SubjectSemesterId { get; set; }
        public int ScheduleInstanceId { get; set; }

    }
}