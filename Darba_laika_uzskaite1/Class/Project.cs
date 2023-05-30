using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darba_laika_uzskaite1
{
    [Serializable]
    public class Project
    {
        public DateTime End { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public BindingList<Task> Task { get; set; } = new BindingList<Task>();
        public Company Company { get; set; }
    }
}
