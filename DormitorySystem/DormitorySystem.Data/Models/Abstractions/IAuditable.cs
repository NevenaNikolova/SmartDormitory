using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Data.Models.Abstractions
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
