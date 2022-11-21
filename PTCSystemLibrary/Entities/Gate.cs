using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCSystemLibrary.Entities
{
    public class Gate
    {
        public int GateNumber { get; set; }
        public List<Person> PersonsCanPass { get; set; }

        public Gate(int gateNumber)
        {
            PersonsCanPass = new List<Person>();
            GateNumber = gateNumber;
        }

        public Gate()
        {
        }

        public void AddPersonAccess(Person person)
        {
            PersonsCanPass.Add(person);
        }
    }
}
