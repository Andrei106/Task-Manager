/**************************************************************************
 *                                                                        *
 *  File:        LoginService.cs                                          *
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManager;

namespace Proxy
{ 
    /// <summary>
    /// Clasa LoginService
    /// </summary>
    public class LoginService : ILogin
    {
        private DatabaseManager.DatabaseManager _databaseManager=DatabaseManager.DatabaseManager.Instance;
        public delegate void LoginAction();
        public static event LoginAction OnLoginSuccessed;
        public static event LoginAction OnLoginFailed;

        /// <summary>
        /// Metoda de login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void LoginMethod(string username, string password)
        {
            var isValid = _databaseManager.CheckUserExits(username,Cryptography.HashString(password)); //Verificare existenta utilizator
            if (isValid)
            {
                //Utilizator gasit
                OnLoginSuccessed?.Invoke(); // event pentru conectare cu succes
                Console.WriteLine("Login successful");
            }
            else
            {
                //Utilizator inexistent
                OnLoginFailed?.Invoke(); // event pentru conectare esuata
                Console.WriteLine("Login unsuccessful");
            }           
        }
    }
}
