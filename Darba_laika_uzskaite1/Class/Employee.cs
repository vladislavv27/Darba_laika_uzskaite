using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darba_laika_uzskaite1
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Employee EmployeeInEmployee { get { return this; } }
    }
}
