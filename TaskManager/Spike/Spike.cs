/**************************************************************************
 *                                                                        *
 *  File:        Spike.cs                                                   *
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
    /// Clasa ce descrie elementele de tip SpikeElement
    /// </summary>
    public class SpikeElement:Elements.TaskElement
    {
        private string _purpose { get; set; }

        /// <summary>
        /// Constructorul clasei SpikeElement
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="description">Descriere</param>
        /// <param name="title">Titlu</param>
        /// <param name="purpose">Scop</param>
        /// <param name="status">Status</param>
        /// <param name="projectId">Id-ul proiectului asociat</param>
        public SpikeElement(int id,string description,string title,string purpose,string status,int projectId):base(id,description,1,title,status, projectId)
        {
            _purpose = purpose;
        }

        /// <summary>
        /// Metoda de returnare a descrierii
        /// </summary>
        /// <returns>Descrierea</returns>
        public string GetDescription()
        {
            return this._description;
        }
        /// <summary>
        /// Metoda de returnare a titlului
        /// </summary>
        /// <returns>Titlu</returns>
        public string GetTitle()
        {
            return this._title;
        }
        /// <summary>
        /// Metoda de returnare a scopului
        /// </summary>
        /// <returns>Scop</returns>
        public string GetPurpose()
        {
            return this._purpose;
        }
        /// <summary>
        /// Metoda ce seteaza a scopului
        /// </summary>
        /// <returns>Scop</returns>
        public void SetPurpose(string purpose)
        {
            this._purpose = purpose;
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
