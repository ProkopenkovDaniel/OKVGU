using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKVGU.Models;

namespace OKVGU.Services
{
    interface IScheduleService
    {
        void Generate(int semId);
        List<Group> GetGroups();
    }
}
