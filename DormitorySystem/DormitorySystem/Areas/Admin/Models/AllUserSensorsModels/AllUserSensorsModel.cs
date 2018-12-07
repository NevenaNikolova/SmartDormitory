using DormitorySystem.Web.Areas.Admin.Models.AllUserSensorsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models.AllUserSensorsModels
{
    public class AllUserSensorsModel
    {
        public AllUserSensorsModel(IEnumerable<SingleAllSensorsModel> allUserSensors)
        {
            AllUserSensors = allUserSensors;
        }

        public IEnumerable<SingleAllSensorsModel> AllUserSensors { get; set; }
    }
}
