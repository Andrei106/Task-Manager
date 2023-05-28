﻿/**************************************************************************
 *                                                                        *
 *  File:        FeatureFactory.cs                                                   *
 *  Copyright:   (c) 2023, Poclid Ionut-Andrei                          *
 *  E-mail:      ionut-andrei.poclid@tuiasi.ro                            *
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
using Elements;
using TaskFactory;

namespace FeatureFactory
{
    /// <summary>
    /// Clasa ce descrie elementele de tip FeatureFactory
    /// </summary>
    public class FeatureFactory:TaskFactory.TaskFactory
    {
        public int _type;

        /// <summary>
        /// Metoda clasei FeatureFactory de crearea a unui FeatureElement
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="description">Descriere</param>
        /// <param name="title">Titlu</param>
        /// <param name="priorityOrSeverity">Prioritate si severitate</param>
        /// <param name="status">Status</param>
        /// <param name="projectId">Id-ul proiectul asociat</param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        public TaskElement CreateTask(int id, string description, string title, int priorityOrSeverity, string status,int projectId, string purpose = "")
        {
            return new Elements.FeatureElement(id, description, title, priorityOrSeverity,status, projectId);
        }
    }
}
