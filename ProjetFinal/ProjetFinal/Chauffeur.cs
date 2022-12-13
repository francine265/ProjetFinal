using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Chauffeur
    {
        String numComducteur;
        String nom;
        String prenom;
        String adresse;
        String email;
        String numero;
        String numCompagnie;
        String motDePasse;


        public Chauffeur()
        {
            this.numComducteur = "";
            this.nom= "";
            this.prenom = "";
            this.adresse = "";
            this.email = "";
            this.numero = "";
            this.numCompagnie= "";
            this.motDePasse = "";
          
        }

        public Chauffeur( string _numConducteur, string _nom, string _prenom, string _adresse, string _email, string _numero, string _numCompagnie, string _motDePasse)
        {

          this.numComducteur = _numConducteur;
          this.nom= _nom;
          this.prenom= _prenom;
          this.adresse= _adresse;
          this.email= _email;
          this.numero= _numero;
          this.numCompagnie= _numCompagnie;
          this.motDePasse= _motDePasse;
        }


        public string NumConducteur { get => numComducteur; set => numComducteur = value; }

        public string Nom { get => nom; set => nom = value; }

        public string Prenom { get => prenom; set => prenom = value; }

        public string Adresse { get => adresse;set=> adresse = value; } 

        public string Email { get => email; set=> email = value; }

        public string Numero { get => numero; set => numero = value;}
    
        public string NumCompagnie { get => numCompagnie; set => numCompagnie = value;}

        public string MotDePasse { get => motDePasse; set => motDePasse = value; }

        public override string ToString()
        {
            return  numComducteur+ " " +nom + " "+ prenom + " " + adresse + " " + email + " " +numero +" " +numCompagnie+" "+motDePasse;
        }
    }
}
