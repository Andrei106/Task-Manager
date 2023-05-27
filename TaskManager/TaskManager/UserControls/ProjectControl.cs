using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoggingModule;


namespace TaskManager
{
    public partial class ProjectControl : UserControl
    {
        private DatabaseManager.DatabaseManager _databaseManager = DatabaseManager.DatabaseManager.Instance;
        private IDictionary<string, string> _projects;
        public ProjectControl()
        {
            InitializeComponent();
            _projects = _databaseManager.GetProjects();
            //List<String> projects = _databaseManager.GetProjects();
            foreach (var project in _projects)
            {
                comboBoxCurrentProject.Items.Add(project.Key);
            }
        }

        private void buttonCreateProject_Click(object sender, EventArgs e)
        {
            string name = textBoxProjectName.Text;
            string description = textBoxProjectDescription.Text;

            if (!Regex.IsMatch(name, @"[^a-zA-Z0-9_]"))
            {
                this._databaseManager.SaveProject(name, description);
                _projects[name] = description;
                comboBoxCurrentProject.Items.Add(name);

                Logger.PopUpIt("User created successfully");
            }
            else {
                Logger.PopUpIt("Invalid data");
            }
        }

        private void comboBoxCurrentProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxCurrentProjectDescription.Text = _projects[comboBoxCurrentProject.SelectedItem.ToString()];
            int selectedProject = comboBoxCurrentProject.SelectedIndex+1;
            if (selectedProject != 0)
                _databaseManager.SelectedProject = selectedProject;
             
        }
        public int ComboBoxSelectedProject
        {
            get { return comboBoxCurrentProject.SelectedIndex + 1; }
        }
    }
}
