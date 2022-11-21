namespace PTCSystemLibrary.Entities
{
    public class ClockingEvent
    {
        public List<DateTime> ClockedIn { get; set; }
        public List<DateTime> ClockedOut { get; set; }
        public bool isClocked { get; set; } = false;
        public ClockingEvent()
        {
            ClockedIn = new List<DateTime>();
            ClockedOut = new List<DateTime>();
        }
        public void RecordTimeStamp(Person person)
        {
            if (person.isClocked == true)
            {
                person.ClockedIn.Add(DateTime.Now);
            }
            else
            {
                person.ClockedOut.Add(DateTime.Now);
            }
        }
        public List<TimeSpan> GetWorkingHours()
        {
            var totalWorkingHours = new List<TimeSpan>();  
        for(int i = 0; i < ClockedOut.Count; i++)
            {
                var workHours = new TimeSpan();
                workHours = ClockedOut[i] - ClockedIn[i];
                totalWorkingHours.Add(workHours);
            }
        return totalWorkingHours;
        }
    }
}
