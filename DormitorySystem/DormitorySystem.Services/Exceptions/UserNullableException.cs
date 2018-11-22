using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Services.Exceptions
{
    public class UserNullableException:Exception
    {
        public UserNullableException(string message):base(message)
        {

        }
    }
}
