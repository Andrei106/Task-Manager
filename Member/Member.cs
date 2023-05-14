using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member
{
    public class Member
    {
        private string _nickname;


        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
    }
}
