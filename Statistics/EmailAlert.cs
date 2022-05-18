namespace Statistics
{
    public class EmailAlert : IAlerter
    {
        public bool EmailSent { get; set; }

        public void SendAlert(bool value)
        {
            EmailSent = value;
        }
    }
}
