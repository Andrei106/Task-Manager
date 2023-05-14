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
        public Task.Task CreateTask()
        {
            return new Spike.Spike();
        }
    }
}
