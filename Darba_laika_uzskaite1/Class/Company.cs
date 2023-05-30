using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darba_laika_uzskaite1
{
    [Serializable]
    public class Company
    {

        public string Name { get; set; }
        public BindingList<Employee> Employee { get; set; } = new BindingList<Employee>();

        public Company CompanyInCompany { get { return this; } }
    }
}
