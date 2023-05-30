using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darba_laika_uzskaite1
{
    [Serializable]
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstimatedTime { get; set; }
        public BindingList<TaskTime> TaskTime { get; set; } = new BindingList<TaskTime>();
    }
}
