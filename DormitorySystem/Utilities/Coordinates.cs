using System;

namespace Utilities
{
    public struct Coordinates
    {
        public string latitude;
        public string longitude;

        public Coordinates(string latitude, string longitude):this()
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
