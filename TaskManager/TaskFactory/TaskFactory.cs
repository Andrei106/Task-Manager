using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFactory
{
    public interface TaskFactory
    {
        Elements.TaskElement CreateTask(int id, string description, string title, int priorityOrSeverity, string purpose = "");
    }
}
