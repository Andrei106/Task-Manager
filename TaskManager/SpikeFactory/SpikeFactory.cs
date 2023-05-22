using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spike;
using TaskFactory;
using Task;
namespace SpikeFactory
{
    public class SpikeFactory:TaskFactory.TaskFactory
    {
        public int _type;
        public Task.Task CreateTask(int id, string description, string title, int priorityOrSeverity, string purpose = "")
        {
            return new Spike.Spike(id, description,title, purpose);
        }
    }
}
