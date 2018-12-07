using DormitorySystem.Data.Models;
using System;

namespace DormitorySystem.Web.Areas.Users.Models.AbstractModels
{
    public class BaseUserSensorViewModel
    {
        public BaseUserSensorViewModel()
        {
        }

        public BaseUserSensorViewModel(UserSensor model)
        {
            Id = model.Id;
            Name = model.Name;
            IsPrivate = model.IsPrivate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
    }
}
