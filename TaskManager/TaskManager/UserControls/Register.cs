﻿/**************************************************************************
 *                                                                        *
 *  File:        Register.cs                                                   *
 *  Copyright:   (c) 2023,Epure Andrei-Ioan                               *
 *  E-mail:      andrei-ioan.epure@student.tuiasi.ro                      *
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseManager;
using LoggingModule;

namespace TaskManager.UserControls
{
    /// <summary>
    /// Clasa Register
    /// </summary>
    public partial class Register : UserControl
    {
        private DatabaseManager.DatabaseManager _databaseManager = DatabaseManager.DatabaseManager.Instance;

        /// <summary>
        /// Constructorul clasei Register
        /// </summary>
        public Register()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(200, Color.Transparent);
            textBoxRegisterPassword.UseSystemPasswordChar = true;
            textBoxRegisterConfirmPassword.UseSystemPasswordChar = true;
        }

        public Action ConnectActionBack { get; set; }

        /// <summary>
        /// Metoda de adaugare a unui nou utilizator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonRegisterAddUser_Click(object sender, EventArgs e)
        {
            // ConnectAction?.Invoke();
            // daca parola contine caractere speciale nu e valida
            if (!Regex.IsMatch(textBoxRegisterUsername.Text, @"[^a-zA-Z0-9_]"))
            {

                // parola trebuie sa aiba minim 8 caractere altfel nu e valida
                if (textBoxRegisterPassword.Text.Length >= 8)
                {
                    //parola trebuie sa fie aceeasi pentru ambele casute
                    if (textBoxRegisterPassword.Text == textBoxRegisterConfirmPassword.Text)
                    {
                        bool successAdded = _databaseManager.SaveUser(textBoxRegisterUsername.Text, Proxy.Cryptography.HashString(textBoxRegisterPassword.Text));
                        if (successAdded)
                        {
                            Logger.PopUpIt("User created successfully");
                            ConnectActionBack?.Invoke();
                        }
                        else
                        {
                            Logger.PopUpIt("User already registered");
                        }
                    }
                    else
                    {
                        Logger.PopUpIt("Different passwords");
                    }
                }
                else
                {
                    Logger.PopUpIt("Too short password");
                }
            }
            else {
                Logger.PopUpIt("Username contains special characters");
            }
        }

        /// <summary>
        /// Getter pentru username
        /// </summary>
        /// <returns>Username</returns>
        public string GetUserText()
        {
            return textBoxRegisterUsername.Text;
        }

        /// <summary>
        /// Setter pentru username
        /// </summary>
        /// <param name="text"></param>
        public void SetUserText(string text)
        {
            textBoxRegisterUsername.Text=text;
        }


        /// <summary>
        /// Getter pentru password
        /// </summary>
        /// <returns>Password</returns>
        public string GetPasswordText()
        {
            return textBoxRegisterPassword.Text;
        }


        /// <summary>
        /// Setter pentru password
        /// </summary>
        /// <param name="text"></param>
        public void SetPasswordText(string text)
        {
            textBoxRegisterPassword.Text = text;
        }


        /// <summary>
        /// Getter pentru confirm password
        /// </summary>
        /// <returns> Confirm Password</returns>
        public string GetConfirmPasswordText()
        {
            return textBoxRegisterConfirmPassword.Text;
        }

        /// <summary>
        /// Setter pentru confirm password
        /// </summary>
        /// <param name="text"></param>
        public void SetConfirmPasswordText(string text)
        {
            textBoxRegisterConfirmPassword.Text = text;
        }


        /// <summary>
        /// Metoda de intoarcere la meniul anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegisterBack_Click(object sender, EventArgs e)
        {
            ConnectActionBack?.Invoke();
        }
    }
}
