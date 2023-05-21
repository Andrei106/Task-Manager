using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Feature
{
    public class Feature:TaskNamespace.Task
    {
        public int Priority { get; set; }

        public Feature(int id, string title, string description, int priority): base(id, description, 0, title)
        {
            this.Priority = priority;
        }
    }
}
