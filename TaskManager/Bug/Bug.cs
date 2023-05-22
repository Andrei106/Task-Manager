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
        public BugElement(int id,string title,string descripition,int severity):base(id,descripition,2,title)
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
    }
}
