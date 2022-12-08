using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class ville
    {


        String choixville;
        int num_administrateur;
        string email;
        string password;
       
        public ville()
        {
            this.choixville = "";
            this.Num_administrateur = 0;
            this.Email = "";
            
        }

        public ville(string choixville, string email, int num_administrateur, string password)
        {
            this.choixville = choixville;
        }

        public string Choixville { get => choixville; set => choixville = value; }
        public int Num_administrateur { get => num_administrateur; set => num_administrateur = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return choixville  + " " + num_administrateur + " " + email + " " + password;
        }


    }
}
