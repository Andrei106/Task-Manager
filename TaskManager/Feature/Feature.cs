using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Elements
{
    public class FeatureElement:Elements.TaskElement
    {
        private int _priority { get; set; }
        public FeatureElement(int id,string descpription,string title,int priority,string status):base(id,descpription,0,title, status)
        {
            _priority = priority;
        }
        public string GetDescription()
        {
            return this._description;
        }
        public string GetTitle()
        {
            return this._title;
        }
        public int GetPriority()
        {
            return this._priority;
        }
        public void SetId(int id)
        {
            this._id = id;
        }
    }
}
