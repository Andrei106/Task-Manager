/**************************************************************************
 *                                                                        *
 *  File:        ProjectControl.cs                                                   *
 *  Copyright:   (c) 2023,Epure Andrei-Ioan                               *
 *  E-mail:      andrei-ioan.epure@student.tuiasi.ro                      *
 *  Description: Student la Facultatea de Automatica si Calculatoare Iasi *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


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
using Project;
namespace TaskManager
{
    /// <summary>
    /// Clasa ProjectControl
    /// </summary>
    public partial class ProjectControl : UserControl
    {
        private DatabaseManager.DatabaseManager _databaseManager = DatabaseManager.DatabaseManager.Instance;
        private IDictionary<string, string> _projects;
        /// <summary>
        /// Constructorul Clasei ProjectControl
        /// </summary>
        public ProjectControl()
        {
            InitializeComponent();
         
            _projects =_databaseManager.GetProjects();


            foreach (var project in _projects)
            {
                comboBoxCurrentProject.Items.Add(project.Key);
            }
        }
        /// <summary>
        /// Metoda de creare a unui proiect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonCreateProject_Click(object sender, EventArgs e)
        {
            string name = textBoxProjectName.Text;
            string description = textBoxProjectDescription.Text;

       

            if (!Regex.IsMatch(name, @"[^a-zA-Z0-9_]"))
            {
                if (comboBoxCurrentProject.FindStringExact(name) == -1)
                {
                    this._databaseManager.SaveProject(name,description);
                    _projects[name] = description;
                    comboBoxCurrentProject.Items.Add(name);

                    Logger.PopUpIt("Project created successfully");

                    textBoxProjectName.Text = "";
                    textBoxProjectDescription.Text = "";
                }
                else {
                    Logger.PopUpIt("Project already exists");
                }
            }
            else {
                Logger.PopUpIt("Invalid data");
            }
        }
        /// <summary>
        /// Metoda de selectare a proiectului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCurrentProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxCurrentProject.SelectedIndex;
            if (index != -1)
            {
                string projectName = comboBoxCurrentProject.SelectedItem.ToString();
                buttonDeleteProject.Visible = true;

                textBoxCurrentProjectDescription.Text =_projects[comboBoxCurrentProject.SelectedItem.ToString()];
                int selectedProject = _databaseManager.GetProjectId(projectName);
                if (selectedProject != -1)
                    _databaseManager.SelectedProject = selectedProject;
            }
        }
        /// <summary>
        /// Metoda de informare a proiectului selectat
        /// </summary>
        /// <returns></returns>
        public int GetComboBoxSelectedProject()
        {
            if (comboBoxCurrentProject.SelectedIndex != -1)
            {
                string name = comboBoxCurrentProject.SelectedItem.ToString();
                return _databaseManager.GetProjectId(name);
            }
            else {
                return -1;
            }
        }
        /// <summary>
        /// Metoda de stergere a unui proiect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonDeleteProject_Click(object sender, EventArgs e)
        {
            if (comboBoxCurrentProject.SelectedIndex != -1)
            {
                string projectName = comboBoxCurrentProject.SelectedItem.ToString();
                int selectedProject = _databaseManager.GetProjectId(projectName);
                if (selectedProject != -1)
                {
                    _databaseManager.DeleteProject(selectedProject);
                    Logger.PopUpIt("Deleted successfully");
                    comboBoxCurrentProject.Items.Remove(projectName);
                    _projects.Remove(projectName);
                    comboBoxCurrentProject.Text = "";
                    textBoxCurrentProjectDescription.Text = "";
                    buttonDeleteProject.Visible = false;
                    
                }
            }
        }
    }
}
