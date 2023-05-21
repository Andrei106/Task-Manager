using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManager;

namespace Proxy
{ 
    public class LoginService : ILogin
    {
        private DatabaseManager.DatabaseManager _databaseManager=DatabaseManager.DatabaseManager.Instance;
        public delegate void LoginAction();
        public static event LoginAction OnLoginSuccessed;
        public static event LoginAction OnLoginFailed;

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
