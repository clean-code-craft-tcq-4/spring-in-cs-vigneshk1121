using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer : StatsComputerBase
    {
        public override Stats CalculateStatistics(List<float> numbers)
        {
            //Implement statistics here
            return new Stats
            {
                Average = numbers.Average(),
                Max = numbers.Max(),
                Min = numbers.Min()
            };
        }

        public Stats CalculateStatistics(List<double> numbers)
        {
            //Implement statistics here
            return new Stats
            {
                Average = numbers.Average(),
                Max = numbers.Max(),
                Min = numbers.Min()
            };
        }
    }
}
