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
            if (!IsValidLoginAttempt(username, password))
            {
                Logger.LogIt("Invalid login attempt");
                return;
            }

            LogLoginAttempt(username);

            // Real Login method
            realLogin.LoginMethod(username, password);
        }

        private bool IsValidLoginAttempt(string username, string password)
        {
            if (Regex.IsMatch(username, @"[^a-zA-Z0-9_]"))
            {
                Logger.PopUpIt("Username contains special characters");
                return false;
            }

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
