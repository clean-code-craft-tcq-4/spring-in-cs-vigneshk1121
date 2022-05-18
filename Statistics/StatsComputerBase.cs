using System.Collections.Generic;

namespace Statistics
{
    public abstract class StatsComputerBase
    {
        public abstract Stats CalculateStatistics(List<float> numbers);
    }
}