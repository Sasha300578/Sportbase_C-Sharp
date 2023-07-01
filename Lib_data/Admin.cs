using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_data
{
    public class Admin
    {
        string login;
        string password;

        public Admin(string l, string p)
        {
            Login = l;
            Password = p;

        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
