/**************************************************************************
 *                                                                        *
 *  File:        LoginProxy.cs                                            *
 *  Copyright:   (c) 2023, Prigoreanu Andrei                              *
 *  E-mail:      andrei.prigoreanu@tuiasi.ro                              *
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

using LoggingModule;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proxy
{
    /// <summary>
    /// Clasa LoginProxy
    /// </summary>
    public class LoginProxy : ILogin
    {
        private readonly ILogin realLogin;

        /// <summary>
        /// Constructorul clasei LoginProxy
        /// </summary>
        public LoginProxy()
        {
            realLogin = new LoginService();
        }

        /// <summary>
        /// Metoda de logare
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void LoginMethod(string username, string password)
        {
            // intai se testeaza daca parola indeplineste conditiile
            if (!IsValidLoginAttempt(username, password))
            {
                Logger.LogIt("Invalid login attempt");
                return;
            }

            LogLoginAttempt(username);

            // Metoda reala din clasa adevarata, aici se va verifica cu intrari din baza de date
            realLogin.LoginMethod(username, password);
        }

        /// <summary>
        /// Metoda de verificare daca incercarea de login e valida
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsValidLoginAttempt(string username, string password)
        {
            // daca parola contine caractere speciale nu e valida
            if (Regex.IsMatch(username, @"[^a-zA-Z0-9_]"))
            {
                Logger.PopUpIt("Username contains special characters");
                return false;
            }

            // parola trebuie sa aiba minim 8 caractere altfel nu e valida
            if (password.Length < 8)
            {
                Logger.PopUpIt("Too short password");
                return false;
            }

            return true;
        }
        /// <summary>
        /// Metoda ce afiseaza o incercare de logare
        /// </summary>
        /// <param name="username"></param>
        private void LogLoginAttempt(string username)
        {
            Logger.LogIt($"Login attempts for user: {username}");
        }
    }
}
