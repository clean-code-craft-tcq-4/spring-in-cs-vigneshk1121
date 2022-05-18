namespace Statistics
{
    public class LEDAlert : IAlerter
    {
        public bool LedGlows { get; set; }

        public void SendAlert(bool value)
        {
            LedGlows = value;
        }
    }
}
