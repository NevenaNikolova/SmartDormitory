using DormitorySystem.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Models.SensorsViewModels
{
    public class SensorsCoordinatesModel
    {
        public SensorsCoordinatesModel(UserSensor model)
        {
            Name = model.Name;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}
