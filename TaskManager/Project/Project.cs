using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member;
namespace Project
{
    public class Project
    {
        private int _id;
        private List<Elements.TaskElement> _tasks;
        private List<Member.Member> _members;

        public bool AddTask(Elements.TaskElement task)
        {
            return true;
        }
        public bool RemoveTask(Elements.TaskElement task)
        {
            return true;
        }
        public List<Elements.TaskElement> GetTasks()
        {
            return _tasks;
        }
    }
}
