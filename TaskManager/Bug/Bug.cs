using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
namespace Bug
{
    public class Bug :Task.Task
    {
        private int _severity { get; set; }
        public Bug(int id,string title,string descripition,int severity):base(id,descripition,2,title)
        {
            _severity = severity;
        }
    }
}
