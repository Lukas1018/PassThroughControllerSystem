using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTCSystemLibrary.Entities;

namespace PTCSystemLibrary.Repositories
{
    public class GateRepository
    {
        private List<Gate> Gates { get; set; }

        public GateRepository()
        {
            Gates = new List<Gate>()
            {
                new Gate(1),
                new Gate(2),
                new Gate(3),
                new Gate(4),
            };
        }
        public List<Gate> GetGates()
        {
            return Gates;
        }
    }
}
