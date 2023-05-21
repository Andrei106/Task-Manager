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
    public class LoginProxy : ILogin
    {
        private readonly ILogin realLogin;

        public LoginProxy()
        {
            realLogin = new LoginService();
        }

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

        private void LogLoginAttempt(string username)
        {
            Logger.LogIt($"Login attempts for user: {username}");
        }
    }
}
