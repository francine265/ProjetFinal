using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class AdminClass
    {

        String email;
        String password;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }


        public override string ToString()
        {
            return  email + " " + password; 

        }
    }
}
