using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNamespace;
using Member;
namespace Project
{
    public class Project
    {
        private int _id;
        private List<TaskNamespace.Task> _tasks;
        private List<Member.Member> _members;

        public bool AddTask(TaskNamespace.Task task)
        {
            return true;
        }
        public bool RemoveTask(TaskNamespace.Task task)
        {
            return true;
        }
        public List<TaskNamespace.Task> GetTasks()
        {
            return _tasks;
        }
    }
}
