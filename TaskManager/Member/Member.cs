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
        private int _id;

        public Member(string nickname, int id)
        {
            Nickname = nickname;
            Id = id;
        }

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
