/**************************************************************************
 *                                                                        *
 *  File:        TaskFactory.cs                                                   *
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

namespace TaskFactory
{
    /// <summary>
    ///  Interfata ce descrie elementele de tip TaskFactory
    /// </summary>
    public interface TaskFactory
    {
        /// <summary>
        /// Metoda interfetei TaskFactory de creare de task-uri
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="title"></param>
        /// <param name="priorityOrSeverity"></param>
        /// <param name="status"></param>
        /// <param name="projectId"></param>
        /// <param name="purpose"></param>
        /// <returns></returns>
        Elements.TaskElement CreateTask(int id, string description, string title, int priorityOrSeverity, string status, int projectId, string purpose = "");
    }
}
