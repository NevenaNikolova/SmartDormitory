using System.Collections.Generic;

namespace DormitorySystem.Data.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
    }
}