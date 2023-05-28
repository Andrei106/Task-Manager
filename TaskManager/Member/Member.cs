/**************************************************************************
 *                                                                        *
 *  File:        Member.cs                                                   *
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

namespace Member
{
    /// <summary>
    /// Clasa ce descrie elementele de tip Member
    /// </summary>
    public class Member
    {
        private string _nickname;
        private int _id;

        /// <summary>
        /// Constructorul clasei Member
        /// </summary>
        /// <param name="nickname">Nickname</param>
        /// <param name="id">Id</param>
        public Member(string nickname, int id)
        {
            Nickname = nickname;
            Id = id;
        }
        /// <summary>
        /// Setter si getter pentru nickname
        /// </summary>
        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        /// Setter si getter pentru id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
