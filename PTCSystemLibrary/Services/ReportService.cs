using PTCSystemLibrary.Entities;

namespace PTCSystemLibrary.Services
{
    public class ReportService
    {
        public List<string> GetWorkingHoursReport(List<Person> personsList)
        {
            var list = new List<string>();
            foreach(Person person in personsList)
            {
                var totalWorkingHours = person.GetWorkingHours();
                TimeSpan tempWorkingHours = new TimeSpan();
                foreach(var workingHours in totalWorkingHours)
                {
                    tempWorkingHours += workingHours;
                }
                string record = $"{person.FirstName} {person.LastName} working hours: {tempWorkingHours.ToString(@"hh\:mm\:ss")}";
                list.Add(record);
            }
            return list;
        }
        public List<string> GetGatesClockingReport(List<Person> persons)
        {
            var reportList = new List<string>();
            var tempPersonsList = new List<Person>();
            foreach(Person person in persons)
            {
                if(person.ClockedIn.Count > 0 || person.ClockedOut.Count > 0)
                {
                    tempPersonsList.Add(person);
                }
            }
            tempPersonsList.OrderBy(person => person.FirstName).ToList();
            foreach(Person person in tempPersonsList)
            {
                for(int i = 0; i < person.ClockedIn.Count; i++)
                {
                    var tempString = $"{person.FirstName} {person.LastName} clocked-in: {person.ClockedIn[i]}";
                    reportList.Add(tempString);
                    if (person.ClockedOut.Count != 0 || person.ClockedOut.Count > i)
                    {
                        tempString = $"{person.FirstName} {person.LastName} clocked-out: {person.ClockedOut[i]}";
                        reportList.Add(tempString);
                    }
                    
                }
            }
            return reportList;
        }
    }
}
