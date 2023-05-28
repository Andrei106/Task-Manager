/**************************************************************************
 *                                                                        *
 *  File:        Logger.cs                                                   *
 *  Copyright:   (c) 2023, Prigoreanu Andrei                            *
 *  E-mail:      andrei.prigoreanu@tuiasi.ro                            *
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

namespace LoggingModule
{
    /// <summary>
    /// Clasa static ce descrie elemente de tip Logger
    /// </summary>
    public static class Logger
    {
        public delegate void MessageLogged(string message);
        public static event MessageLogged OnPopUpMessageLogged;

        /// <summary>
        /// Metoda de pop up a unui mesaj
        /// </summary>
        /// <param name="message"></param>
        public static void PopUpIt(string message)
        {
            OnPopUpMessageLogged?.Invoke(message);
        }

        /// <summary>
        /// Metoda de printare a rezultatului loginului 
        /// </summary>
        /// <param name="message"></param>
        public static void LogIt(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Metoda de printare a rezultatului loginului 
        /// </summary>
        /// <param name="message"></param>
        public static void PopAndLogIt(string message) 
        {
            Console.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
