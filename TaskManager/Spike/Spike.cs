using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Elements
{
    public class SpikeElement:Elements.TaskElement
    {
        private string _purpose { get; set; }
        public SpikeElement(int id,string description,string title,string purpose,string status):base(id,description,1,title,status)
        {
            _purpose = purpose;
        }
        public string GetDescription()
        {
            return this._description;
        }
        public string GetTitle()
        {
            return this._title;
        }
        public string GetPurpose()
        {
            return this._purpose;
        }
        public void SetId(int id)
        {
            this._id = id;
        }
    }
}
