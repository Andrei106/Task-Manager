using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements;
using TaskFactory;

namespace FeatureFactory
{
    public class FeatureFactory:TaskFactory.TaskFactory
    {
        public int _type;

        TaskElement TaskFactory.TaskFactory.CreateTask(int id, string description, string title, int priorityOrSeverity, string purpose)
        {
            throw new NotImplementedException();
        }
    }
}
