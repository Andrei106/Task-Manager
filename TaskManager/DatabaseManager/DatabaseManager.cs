using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;
namespace DatabaseManager
{
    public class DatabaseManager
    {
        private string _url;

        public bool SaveProject(Project.Project project)
        {
            return true;
        }
        public bool SaveTask(Feature.Feature task)
        {
            return true;
        }
        public bool SaveTask(Spike.Spike task)
        {
            return true;
        }
        public bool SaveTask(Bug.Bug task)
        {
            return true;
        }
    }
}
