using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingModule
{
    public static class Logger
    {
        public delegate void MessageLogged(string message);
        public static event MessageLogged OnPopUpMessageLogged;

        public static void PopUpIt(string message)
        {
            OnPopUpMessageLogged?.Invoke(message);
        }

        public static void LogIt(string message)
        {
            Console.WriteLine(message);
        }

        public static void PopAndLogIt(string message) 
        {
            Console.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
