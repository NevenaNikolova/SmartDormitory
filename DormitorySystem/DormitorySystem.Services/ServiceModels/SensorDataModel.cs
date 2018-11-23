using System;

namespace DormitorySystem.Services.ServiceModels
{
    internal class SensorDataModel
    {
        private int minPollingInterval;
        private DateTime timeStamp;

        public SensorDataModel(string id, string minPollingInterval)
        {
            try
            {
                this.MinPollingInterval = int.Parse(minPollingInterval);
            }
            catch (FormatException)
            {
                throw new FormatException("The value for Min Polling Interval isn't a integer");
            }

            this.Id = id;
            this.TimeStamp = DateTime.Now
                .Subtract(DateTime.Now.AddSeconds(this.MinPollingInterval) - DateTime.Now);
        }

        public string Id { get; set; }
        public DateTime TimeStamp
        {
            get => timeStamp;
            set
            {
                timeStamp = value.AddSeconds(this.MinPollingInterval);
            }
        }
        public int MinPollingInterval
        {
            get => minPollingInterval;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("MinPollingInterval can't be less then 1 seconds or negative value");
                }
                minPollingInterval = value;
            }
        }
    }
}
