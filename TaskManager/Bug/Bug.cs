using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Elements
{
    public class BugElement :Elements.TaskElement
    {
        private int _severity { get; set; }
        public BugElement(int id,string title,string descripition,int severity,string status):base(id,descripition,2,title,status)
        {
            _severity = severity;
        }
        public string GetDescription()
        {
            return this._description;
        }
        public string GetTitle()
        {
            return this._title;
        }
        public int GetSeverity()
        {
            return this._severity;
        }
        public void SetSeverity(int severity)
        {
            this._severity = severity;
        }
        public void SetId(int id)
        {
            this._id = id;
        }
    }
}
