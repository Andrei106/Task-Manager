using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
namespace TaskFactory
{
    public interface TaskFactory
    {
        Task.Task CreateTask();
    }
}
