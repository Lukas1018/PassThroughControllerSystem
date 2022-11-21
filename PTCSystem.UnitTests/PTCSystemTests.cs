using PTCSystemLibrary.Entities;
using PTCSystemLibrary.Repositories;
using PTCSystemLibrary.Services;
using Xunit;

namespace PTCSystem.UnitTests
{
    public class PTCSystemTests
    {
        [Fact]
        public void GeneratePersonsGateAccessTest()
        {
            var personRepository = new PersonRepository();
            var gateRepository = new GateRepository();
            var persons = personRepository.GetPersons();
            var gates = gateRepository.GetGates();
            var controller = new PassThroughControllerService();
            controller.GeneratePersonsGateAccess(gates, persons);

            Assert.Equal(3, gates[0].PersonsCanPass.Count);
        } 

        [Fact]
        public void GetGateByIdTest()
        {
            var personRepository = new PersonRepository();
            var gateRepository = new GateRepository();
            var persons = personRepository.GetPersons();
            var gates = gateRepository.GetGates();
            var controller = new PassThroughControllerService();
            controller.GeneratePersonsGateAccess(gates, persons);

            var result = controller.GetGateById(gates, 1234);

            Assert.Equal(gates[0], result);
        }

        [Fact]
        public void ChangeClockingStatusTest()
        {
            var controller = new PassThroughControllerService();
            var person = new Person(1112, "Kazys", "Maksvytis");
            controller.ChangeClockingStatus(person);
            Assert.Equal(true, person.isClocked);
        }
        [Fact]
        public void GetGatesClockingReport()
        {
            var report = new ReportService();
            var persons = new List<Person>()
            {
                new Person(1111, "Adas", "Juskevicius")
            };
            persons[0].ClockedIn.Add(DateTime.Now);
            string expected = $"Adas Juskevicius clocked-in: {DateTime.Now}";
            var result = report.GetGatesClockingReport(persons);

            Assert.Equal(expected, result[0]);

        }
    }
}