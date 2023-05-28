/**************************************************************************
 *                                                                        *
 *  File:        Task.cs                                                   *
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
using Member;

namespace Elements
{
    /// <summary>
    /// Clasa abstracta ce descrie elementele de tip TaskElement
    /// </summary>
    public abstract class TaskElement
    {
        protected int _id;
        //protected State _currentState;
        protected string _description { get; set; }
        protected int _type;
        protected string _status { get; set; }
        protected string _title { get; set; }
        protected Member.Member currentAsignee;
        protected Member.Member reporter;

        protected int _projectId;
        // protected Button edit;
        /// <summary>
        /// Getter id
        /// </summary>
        public int ProjectId {
            get { return _projectId; }

        }
        /// <summary>
        /// Getter tip
        /// </summary>
        public int Type
        {
            get { return _type; }

        }
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="description">Descriere</param>
        /// <param name="type">Tip</param>
        /// <param name="title">Titlu</param>
        /// <param name="status">Status</param>
        /// <param name="projectId">Id-ul proiectului asociat</param>
        public TaskElement(int id, string description, int type, string title, string status,int projectId)
        {
            this._id = id;
            this._description = description;
            this._type = type;
            this._title = title;
            this._status = status;
            this._projectId = projectId;
        }
       /// <summary>
       /// Getter id
       /// </summary>
       /// <returns></returns>
        public int GetId()
        {
            return _id;
        }
        /// <summary>
        /// Getter status
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            return _status;
        }
        /// <summary>
        /// Setter status
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(string status)
        {
            this._status = status;
        }
        /// <summary>
        /// Setter si getter titlu
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Setter si getter description
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Setter si getter currentAsignee
        /// </summary>
        public Member.Member CurrentAsignee {
            get { return currentAsignee; }
            set { currentAsignee = value; }
        }
        /// <summary>
        /// Setter si getter Reporter
        /// </summary>
        public Member.Member Reporter
        {
            get { return reporter; }
            set { reporter = value; }
        }
    }
}
