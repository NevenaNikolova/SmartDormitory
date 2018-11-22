using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Data.Models.Abstractions
{
    public interface IDeletable
    {
        bool isDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}
