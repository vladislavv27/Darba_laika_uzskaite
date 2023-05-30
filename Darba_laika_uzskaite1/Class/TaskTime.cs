using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darba_laika_uzskaite1
{
    [Serializable]
    public class TaskTime
    {
        public Employee Employee { get; set; }
        public TimeSpan Time { get; set; }
    }
}
