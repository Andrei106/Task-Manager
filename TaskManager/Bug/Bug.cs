/**************************************************************************
 *                                                                        *
 *  File:        Bug.cs                                                   *
 *  Copyright:   (c) 2023, Lungu Bogdan-Andrei                            *
 *  E-mail:      bogdan-andrei.lungu@tuiasi.ro                            *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Elements
{
    /// <summary>
    /// Clasa ce descrie elementele de tip BugElement
    /// </summary>
    public class BugElement :Elements.TaskElement
    {


        private int _severity { get; set; }
        
        /// <summary>
        /// Constructorul clasei BugElement
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="title">Titlu</param>
        /// <param name="descripition">Descriere</param>
        /// <param name="severity">Severitate</param>
        /// <param name="status">Status</param>
        /// <param name="projectId">Id ul proiectului asociat</param>
        public BugElement(int id,string descripition, string title,int severity,string status,int projectId):base(id,descripition,2,title,status,projectId)
        {
            _severity = severity;
        }

        /// <summary>
        /// Metoda ce returneaza descrierea
        /// </summary>
        /// <returns>Descrierea</returns>
        public string GetDescription()
        {
            return this._description;
        }

        /// <summary>
        /// Metoda ce returneaza titlul
        /// </summary>
        /// <returns>Titlul</returns>
        public string GetTitle()
        {
            return this._title;
        }

        /// <summary>
        /// Metoda ce returneaza severitatea
        /// </summary>
        /// <returns>Severitatea</returns>
        public int GetSeverity()
        {
            return this._severity;
        }

        /// <summary>
        /// Metoda ce seteaza nivelul de severitate
        /// </summary>
        /// <returns>Severitate</returns>
        public void SetSeverity(int severity)
        {
            this._severity = severity;
        }

        /// <summary>
        /// Metoda ce seteaza id-ul taskului de tip BugElement
        /// </summary>
        /// <returns>Id</returns>
        public void SetId(int id)
        {
            this._id = id;
        }
    }
}
