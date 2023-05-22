using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
namespace Spike
{
    public class Spike:Task.Task
    {
        private string _purpose { get; set; }
        public Spike(int id,string description,string title,string purpose):base(id,description,1,title)
        {
            _purpose = purpose;
        }
    }
}
