using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member;
namespace Project
{
    public class Project
    {
        private string _name;
        private string _description;

        public Project(string name, string description)
        {
            this._name = name;
            this._description = description;
        }

        public string Name
        {
            set { this._name = value; }
            get { return this._name; }
        }

        public string Description
        {
            set { this._description = value; }
            get { return this._description; }
        }
    }
}
