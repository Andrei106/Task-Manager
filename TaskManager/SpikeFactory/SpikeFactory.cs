using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements;
using TaskFactory;
namespace SpikeFactory
{
    public class SpikeFactory:TaskFactory.TaskFactory
    {
        public int _type;

        public TaskElement CreateTask(int id, string description, string title, int priorityOrSeverity, string status, string purpose = "")
        {
            return new Elements.SpikeElement(id, description, title, purpose,status);
        }
    }
}
