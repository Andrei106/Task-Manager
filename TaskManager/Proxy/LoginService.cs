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
            // (Andrei Ioan E.) Te rog foloseste codul din L9 pentru partea cu criptarea
            // In baza de date ar trebui sa avem username-ul in "alb" si parola criptata

            var isValid = false; // pentru test, daca e true conctarea are loc
            if(isValid)
            {
                OnLoginSuccessed?.Invoke(); // event pentru conectare cu succes
                Console.WriteLine("Login successful");
            }
            else
            {
                OnLoginFailed?.Invoke(); // event pentru conectare esuata
                Console.WriteLine("Login unsuccessful");
            }           
        }
    }
}
