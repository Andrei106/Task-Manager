using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class LoginService : ILogin
    {
        public delegate void LoginAction();
        public static event LoginAction OnLoginSuccessed;
        public static event LoginAction OnLoginFailed;

        public void LoginMethod(string username, string password)
        {
            // Implementation of the actual login logic
            // (Andrei Ioan E.) Check data from data base

            var isValid = false;
            if(isValid)
            {
                OnLoginSuccessed?.Invoke();
                Console.WriteLine("Login successful");
            }
            else
            {
                OnLoginFailed?.Invoke();
                Console.WriteLine("Login unsuccessful");
            }           
        }
    }
}
