using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public abstract class TaskElement
    {
        protected int _id;
        //protected State _currentState;
        protected string _description { get; }
        protected int _type;//instead of TaskType we could use an integer as well
        protected string _title { get; }
        // protected Button edit;

        public TaskElement(int id,string description,int type,string title)
        {
            this._id = id;
            this._description = description;
            this._type = type;
            this._title = title;
        }
        public void TaskComplete() { 
        
        }
    }
}
