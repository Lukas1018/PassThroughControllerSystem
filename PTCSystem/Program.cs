using PTCSystemLibrary;
using PTCSystemLibrary.Entities;
using PTCSystemLibrary.Repositories;
using PTCSystemLibrary.Services;

public class Program
{
    public static void Main()
    {
        var personRepository = new PersonRepository();
        var gateRepository = new GateRepository();
        var persons = personRepository.GetPersons();
        var gates = gateRepository.GetGates();
        var clocking  = new ClockingEvent();
        var controller = new PassThroughControllerService();
        var report = new ReportService();
        var file = new FileService();
        
        controller.GeneratePersonsGateAccess(gates, persons);

        Console.WriteLine("\t\t--Pass Through Gates Control System--\n");
        bool isProgramRunning = true;
        while (isProgramRunning)
        {
            int gateChoise = 0;
            Console.WriteLine("Choose Gate:\n[1] Gate 1\n[2] Gate 2\n[3] Gate 3\n[4] Gate 4\n[5] Exit");
            bool isChoosed = int.TryParse(Console.ReadLine(), out gateChoise);
            while(gateChoise>gates.Count + 1 || !isChoosed == true)
            {
                Console.WriteLine("\nerror: wrong input.\n");
                Console.WriteLine("Choose Gate:\n[1] Gate 1\n[2] Gate 2\n[3] Gate 3\n[4] Gate 4\n[5] Exit");
                isChoosed = int.TryParse(Console.ReadLine(), out gateChoise);
            }
            if(gateChoise == 5)
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Please enter your ID:");
            bool isNotEntered = true;
            int enteredId = 0;
            while (isNotEntered)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out enteredId);
                if (!isNumber)
                {
                    Console.WriteLine("error: entered ID is not numbers. Please, try again!\n");
                    Console.WriteLine("Please enter your ID:");
                }
                else
                {
                    isNotEntered = false;
                }
            }
            try
            {
                var gateById = controller.GetGateById(gates, enteredId);
                var personById = gateById.PersonsCanPass.Find(x => x.Id == enteredId);
                if(gateById.GateNumber == gates[gateChoise - 1].GateNumber)
                {
                    controller.ChangeClockingStatus(personById);
                    clocking.RecordTimeStamp(personById);
                    switch (personById.isClocked)
                    {
                        case true:
                            Console.WriteLine($"\nGate: {gateById.GateNumber}\nClocked-in: {personById.FirstName} {personById.LastName}.\n");
                            break;
                        case false:
                            Console.WriteLine($"\nGate: {gateById.GateNumber}\nClocked-out: {personById.FirstName} {personById.LastName}.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nAccess Denied!\n");
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("\nPerson by ID not found\n");
            }

            var personsWorkingHoursList = report.GetWorkingHoursReport(persons);
            var gatesClockingReport = report.GetGatesClockingReport(persons);
            file.ConvertPersonsWorkingHoursToCsvFile(personsWorkingHoursList);
            file.ConvertClockingReportToCsvFile(gatesClockingReport);
        }
    }
}
