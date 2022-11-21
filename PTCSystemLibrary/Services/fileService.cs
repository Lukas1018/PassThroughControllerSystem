using PTCSystemLibrary.Entities;

namespace PTCSystemLibrary.Services
{
    public class FileService
    {
        public List<Person> ConvertCsvFileToPersonsList()
        {
            string personsFilePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\Persons.csv";
            var personsList = new List<Person>();
            var tempList = new List<string[]>();

            if (File.Exists(personsFilePath))
            {
                using (StreamReader sr = new StreamReader(personsFilePath))
                {
                    string header = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        string[] person = line.Split(",");
                        tempList.Add(person);
                    }
                }
                foreach (var person in tempList)
                {
                    try
                    {
                        var tempPerson = new Person();
                        tempPerson.Id = Convert.ToInt32(person[0]);
                        tempPerson.FirstName = person[1];
                        tempPerson.LastName = person[2];
                        personsList.Add(tempPerson);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(person[0]);
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
            return personsList;
        } public List<string[]> ConvertCsvFileToPersonsGateAccessList()
        {
            string personsFilePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\Persons gate access.csv";
            var personsAccessList = new List<string[]>();

            if (File.Exists(personsFilePath))
            {
                using (StreamReader sr = new StreamReader(personsFilePath))
                {
                    string header = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        string[] person = line.Split(",");
                        personsAccessList.Add(person);
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
            return personsAccessList;
        }
        public void ConvertPersonsWorkingHoursToCsvFile(List<string> report)
        {
            string workingHoursFile = AppDomain.CurrentDomain.BaseDirectory + "Data\\Working hours report.csv";
            using (StreamWriter sw = new StreamWriter(workingHoursFile))
            {
                foreach(var person in report)
                {
                    sw.WriteLine(person);
                }
                sw.Close();
            }
        }public void ConvertClockingReportToCsvFile(List<string> report)
        {
            string workingHoursFile = AppDomain.CurrentDomain.BaseDirectory + "Data\\All gates clocking report.csv";
            using (StreamWriter sw = new StreamWriter(workingHoursFile))
            {
                foreach(var person in report)
                {
                    sw.WriteLine(person);
                }
                sw.Close();
            }
        }
    }
}
