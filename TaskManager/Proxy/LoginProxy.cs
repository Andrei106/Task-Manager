using System;
using System.Collections.Generic;
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
                Console.WriteLine("Invalid login attempt");
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
                Console.WriteLine("Username contains special characters");
                return false;
            }

            if (password.Length < 8)
            {
                Console.WriteLine("Too short password");
                return false;
            }

            return true;
        }

        private void LogLoginAttempt(string username)
        {
            // Perform logging operations, such as writing to a log file or database
            Console.WriteLine($"Login attempt for user: {username}");
        }
    }
}
