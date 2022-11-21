using PTCSystemLibrary.Entities;
using PTCSystemLibrary.Services;

namespace PTCSystemLibrary.Repositories
{
    public class PersonRepository
    {
        private FileService CsvReader = new FileService();
        private List<Person> Persons { get; set; }

        public PersonRepository()
        {
            Persons = CsvReader.ConvertCsvFileToPersonsList();
        }
        public List<Person> GetPersons()
        {
            return Persons;
        }
    }
}
