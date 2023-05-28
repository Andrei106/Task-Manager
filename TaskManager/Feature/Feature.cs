/**************************************************************************
 *                                                                        *
 *  File:        Feature.cs                                                   *
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
    /// Clasa ce descrie elementele de tip FeatureElement
    /// </summary>
    public class FeatureElement:Elements.TaskElement
    {
        private int _priority { get; set; }
       
        /// <summary>
        /// Constructorul clasei FeatureElement
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="description">Descriere</param>
        /// <param name="title">Title</param>
        /// <param name="priority">Prioritatea</param>
        /// <param name="status">Status</param>
        /// <param name="projectId">Id-ul proiectului</param>
        public FeatureElement(int id,string description,string title,int priority,string status, int projectId) :base(id, description, 0,title, status,projectId)
        {
            _priority = priority;
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
        /// Metoda ce returneaza titlu
        /// </summary>
        /// <returns>Titlul</returns>
        public string GetTitle()
        {
            return this._title;
        }

        /// <summary>
        /// Metoda ce returneaza prioritate
        /// </summary>
        /// <returns>Prioritate</returns>
        public int GetPriority()
        {
            return this._priority;
        }
        /// <summary>
        /// Metoda ce seteaza prioritate
        /// </summary>
        /// <returns>Prioritate</returns>
        public void SetPriority(int priority)
        {
            this._priority = priority;
        }
        /// <summary>
        /// Metoda ce seteaza id-ul
        /// </summary>
        /// <returns>Id</returns>
        public void SetId(int id)
        {
            this._id = id;
        }
    }
}
