using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
using TaskFactory;
using Bug;
namespace BugFactory
{
    public class BugFactory:TaskFactory.TaskFactory
    {
        public int _type;
        public Task.Task CreateTask(int id, string description, string title, int priorityOrSeverity, string purpose = "")
        {
            return new Bug.Bug(id, title, description, priorityOrSeverity);
        }
    }
}
