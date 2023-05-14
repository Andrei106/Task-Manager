using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
using Member;
namespace Project
{
    public class Project
    {
        private int _id;
        private List<Task.Task> _tasks;
        private List<Member.Member> _members;

        public bool AddTask(Task.Task task)
        {
            return true;
        }
        public bool RemoveTask(Task.Task task)
        {
            return true;
        }
        public List<Task.Task> GetTasks()
        {
            return _tasks;
        }
    }
}
