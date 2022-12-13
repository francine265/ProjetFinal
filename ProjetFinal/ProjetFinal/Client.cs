using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Client
    {

        int num_Client;
        string nom_Client;
        string prenom_Client;
        string adresse_Client;
        string email_Client;
        string num_Telephone_Client;
        int num_Conducteur;

        public Client()
        {
            num_Client = 0;
            nom_Client = "";
            prenom_Client = "";
            adresse_Client = "";
            email_Client = "";
            num_Telephone_Client = "";
            num_Conducteur = 0;
        }

        public Client(int num_Client, string nom_Client, string prenom_Client, string adresse_Client, string email_Client, string num_Telephone_Client, int num_Conducteur)
        {
            this.Num_Client = num_Client;
            this.Nom_Client = nom_Client;
            this.Prenom_Client = prenom_Client;
            this.Adresse_Client = adresse_Client;
            this.Email_Client = email_Client;
            this.Num_Telephone_Client = num_Telephone_Client;
            this.Num_Conducteur = num_Conducteur;
        }

        public int Num_Client { get => num_Client; set => num_Client = value; }
        public string Nom_Client { get => nom_Client; set => nom_Client = value; }
        public string Prenom_Client { get => prenom_Client; set => prenom_Client = value; }
        public string Adresse_Client { get => adresse_Client; set => adresse_Client = value; }
        public string Email_Client { get => email_Client; set => email_Client = value; }
        public string Num_Telephone_Client { get => num_Telephone_Client; set => num_Telephone_Client = value; }
        public int Num_Conducteur { get => num_Conducteur; set => num_Conducteur = value; }


    }
}
