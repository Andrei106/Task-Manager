using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
namespace Feature
{
    public class Feature:Task.Task
    {
        private int _priority { get; set; }
        public Feature(int id,string descpription,string title,int priority):base(id,descpription,0,title)
        {
            _priority = priority;
        }
    }
}
