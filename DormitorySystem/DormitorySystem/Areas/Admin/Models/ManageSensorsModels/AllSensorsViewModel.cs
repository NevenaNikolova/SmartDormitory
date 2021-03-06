﻿using System.Collections.Generic;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels
{
    public class AllSensorSViewModel
    {
        public AllSensorSViewModel(IEnumerable<AllSensorViewModel> allUserSensors)
        {
            this.AllUserSensors = allUserSensors;
        }

        public IEnumerable<AllSensorViewModel> AllUserSensors { get; set; }
    }
}
