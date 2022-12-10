using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Client
    {
        String nom_client;
        string prenom_client;
        String adresse;
        string email;
        String password;
        string numeroPhone;

        public string Nom_client { get => nom_client; set => nom_client = value; }
        public string Prenom_client { get => prenom_client; set => prenom_client = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string NumeroPhone { get => numeroPhone; set => numeroPhone = value; }

        public override string ToString()
        {
            return nom_client + " " + prenom_client + " " + adresse +" " + email + " " +password + " "+ numeroPhone;
        }
    }
}
