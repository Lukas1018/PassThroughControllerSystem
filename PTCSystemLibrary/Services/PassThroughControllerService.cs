using PTCSystemLibrary.Entities;
using PTCSystemLibrary.Repositories;

namespace PTCSystemLibrary.Services
{
    public class PassThroughControllerService
    {
        public void GeneratePersonsGateAccess(List<Gate> gatesList, List<Person> persons)
        {
            var file = new FileService();
            var accessList = file.ConvertCsvFileToPersonsGateAccessList();
            for (int i = 0; i <persons.Count ; i++)
            {
                foreach(var person in accessList)
                {
                    if (Convert.ToInt32(person[1]) == persons[i].Id)
                    {
                        gatesList[Convert.ToInt32(person[0]) - 1].AddPersonAccess(persons[i]);
                    }
                }
            }
        }
        public Gate GetGateById(List<Gate> gatesList, int id)
        {
            var tempGate = new Gate();
            foreach(var gate in gatesList)
            {
                bool isExisting = gate.PersonsCanPass.Exists(person => person.Id == id);
                if (isExisting)
                {
                    tempGate = gate;
                    break;
                } 
            }
            return tempGate;
        }
        public void ChangeClockingStatus(Person person)
        {
            if(person.isClocked == false)
            {
                person.isClocked = true;
            }
            else if(person.isClocked == true)
            {
                person.isClocked = false;
            }   
        }
    }
}
