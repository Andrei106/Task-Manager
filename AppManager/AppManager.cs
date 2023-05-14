using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;
using TaskFactory;
namespace AppManager
{
    public class AppManager
    {

        private List<Project.Project> _projects;
        private TaskFactory.TaskFactory _taskFactory;

        public bool AddProject(Project.Project project) {
            return true;
        }

        public bool RemoveProject(Project.Project project)
        {
            return true;
        }

        public Project.Project GetCurrentProject()
        {
            return new Project.Project();
        }
        public List<Project.Project> GeProjects()
        {
            return _projects;
        }


    }


}
