using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsAlerter
    {
        public float MaxThreshold { get; set; }

        public IAlerter[] Alerters { get; set; }

        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            MaxThreshold = maxThreshold;
            Alerters = alerters;
        }

        public void CheckAndAlert(List<float> numbers)
        {
            foreach (var item in numbers)
            {
                if (item > MaxThreshold)
                {
                    Alerters.ToList().ForEach(alert => alert.SendAlert(true));
                }
            }
        }
    }
}
