using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements;

namespace TaskFactory
{
    public class TaskFactoryImpl : TaskFactory
    {
        public TaskElement CreateTask(int id, string description, string title, int priorityOrSeverity, string purpose = "")
        {
            throw new NotImplementedException();
        }
    }
}
