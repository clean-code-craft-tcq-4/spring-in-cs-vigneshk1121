using System;
using Xunit;
using System.Collections.Generic;

namespace Statistics.Test
{
    public class StatsUnitTest
    {
        [Fact]
        public void ReportsAverageMinMax()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<float> { 1.5F, 8.9F, 3.2F, 4.5F });
            float epsilon = 0.001F;
            Assert.True(Math.Abs(computedStats.Average - 4.525) <= epsilon);
            Assert.True(Math.Abs(computedStats.Max - 8.9) <= epsilon);
            Assert.True(Math.Abs(computedStats.Min - 1.5) <= epsilon);
        }

        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            
            var computedStats = statsComputer.CalculateStatistics(
                new List<double> {double.NaN, double.NaN, double.NaN, double.NaN });
            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1

            Assert.True(computedStats.Average.Equals(double.NaN));
            Assert.True(computedStats.Max.Equals(double.NaN));
            Assert.True(computedStats.Min.Equals(double.NaN));
        }

        [Fact]
        public void RaisesAlertsIfMaxIsMoreThanThreshold()
        {
            var emailAlert = new EmailAlert();
            var ledAlert = new LEDAlert();
            IAlerter[] alerters = { emailAlert, ledAlert };

            const float maxThreshold = 10.2F;
            var statsAlerter = new StatsAlerter(maxThreshold, alerters);
            statsAlerter.CheckAndAlert(new List<float> { 0.2F, 11.9F, 4.3F, 8.5F });

            Assert.True(emailAlert.EmailSent);
            Assert.True(ledAlert.LedGlows);
        }
    }
}
