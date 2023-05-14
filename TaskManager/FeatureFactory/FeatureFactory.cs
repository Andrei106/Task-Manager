using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFactory;
using Task;
using Feature;
namespace FeatureFactory
{
    public class FeatureFactory:TaskFactory.TaskFactory
    {
        public int _type;
        public Task.Task CreateTask()
        {
            return new Feature.Feature();
        }
    }
}
