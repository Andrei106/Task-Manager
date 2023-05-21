using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bug
{
    public class Bug :TaskNamespace.Task
    {
        public int Severity { get; set; }

        public Bug(int id, string title, string description, int severity) : base(id, description, 2, title)
        {
            this.Severity = severity;
        }
    }
}
