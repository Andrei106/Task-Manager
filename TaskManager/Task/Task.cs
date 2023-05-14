using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public abstract class Task
    {
        protected int _id;
        //protected State _currentState;
        protected string _description;
        protected int _type;//instead of TaskType we could use an integer as well
        protected string _title;
        // protected Button edit;
        public void TaskComplete() { 
        
        }
    }
}
