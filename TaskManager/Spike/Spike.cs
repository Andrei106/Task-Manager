using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Spike
{
    public class Spike:TaskNamespace.Task
    {
        public string Purpose { get; set; }

        public Spike(int id, string title, string description, string purpose) : base(id, description, 1, title)
        {
            this.Purpose = purpose;
        }
    }
}
