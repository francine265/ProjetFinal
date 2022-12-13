using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace ProjetFinal
{
    internal class Trajets
    {
        int num_Trajet;
        String ville_Depart;
        String ville_Arrivee;
      /*  DateTime heure_Depart;
        DateTime heure_Arrivee;*/
        String date_Trajet;
        String prix_Trajet;
        String heureDepartString;
        String heureArriveeString;
        String arret;
        int nombre_Place_dispo;
        String etat;
        int num_Conducteur;
        String num_tel_Conducteur;
        String prenom_Conducteur;
        String nom_Conducteur;

        double prixTrajet;
        String conducteur;
        int montant_total;
        int montant_compagnie;
        int montant_chauffeur;
        String totalRevenue;
        String totalRevenueEntreprise;

        int nombre_Place_Initiales;


        public Trajets()
        {
            this.num_Trajet = 0;
            this.ville_Depart = "";
            this.ville_Arrivee = "";
            /*this.heure_Depart = new DateTime();
            this.heure_Arrivee = new DateTime();*/
            this.HeureArriveeString = "";
            this.HeureDepartString = "";
            this.Nom_Conducteur = "";
            this.Prenom_Conducteur = "";
            this.date_Trajet = "";
            this.prix_Trajet = "";
            this.arret = "";
            this.nombre_Place_dispo = 0;
            this.etat = "";
            this.num_Conducteur = 0;
            this.Num_tel_Conducteur = "";
        }

       

        public Trajets(int num_Trajet, string ville_Depart, string ville_Arrivee, string _adebut, string prix_Trajet, string arret, int nombre_Place_dispo, string etat, int num_Conducteur , String _heureDepartString, string nom_Conducteur, string prenom_Conducteur,string num_tel_Conducteur,
       String _heureArriveeString)
        {
            this.num_Trajet = num_Trajet;
            this.ville_Depart = ville_Depart;
            this.ville_Arrivee = ville_Arrivee;
            /*this.heure_Depart = new DateTime( hour, minute,second);
            this.heure_Arrivee = new DateTime(_hour, _minute, _second); */
            this.date_Trajet ="";
            this.prix_Trajet = prix_Trajet;
            this.arret = arret;
            this.nombre_Place_dispo = nombre_Place_dispo;
            this.etat = etat;
            this.num_Conducteur = num_Conducteur;
            this.HeureDepartString = _heureDepartString;
            this.HeureArriveeString = _heureArriveeString;
            this.Nom_Conducteur = nom_Conducteur;
            this.Prenom_Conducteur = prenom_Conducteur;
        }

        public int Num_Trajet { get => num_Trajet; set => num_Trajet = value; }
        public string Ville_Depart { get => ville_Depart; set => ville_Depart = value; }
        public string Ville_Arrivee { get => ville_Arrivee; set => ville_Arrivee = value; }
      /*  public DateTime Heure_Depart { get => heure_Depart; set => heure_Depart = value; }
        public DateTime Heure_Arrivee { get => heure_Arrivee; set => heure_Arrivee = value; }*/
        public String Date_Trajet { get => date_Trajet; set => date_Trajet = value; }
        public String Prix_Trajet { get => prix_Trajet; set => prix_Trajet = value; }

        public String Arret { get => arret; set => arret = value; }
        public int Nombre_Place_dispo { get => nombre_Place_dispo; set => nombre_Place_dispo = value; }
        public String Etat { get => etat; set => etat = value; }
        public int Num_Conducteur { get => num_Conducteur; set => num_Conducteur = value; }
        public string HeureDepartString { get => heureDepartString; set => heureDepartString = value; }
        public string HeureArriveeString { get => heureArriveeString; set => heureArriveeString = value; }
        public string Nom_Conducteur { get => nom_Conducteur; set => nom_Conducteur = value; }
        public string Prenom_Conducteur { get => prenom_Conducteur; set => prenom_Conducteur = value; }
        public string Num_tel_Conducteur { get => num_tel_Conducteur; set => num_tel_Conducteur = value; }

        public string Conducteur { get => conducteur; set => conducteur = value; }
        public int Montant_total { get => montant_total; set => montant_total = value; }
        public int Montant_compagnie { get => montant_compagnie; set => montant_compagnie = value; }
        public int Montant_chauffeur { get => montant_chauffeur; set => montant_chauffeur = value; }
        public string TotalRevenue { get => totalRevenue; set => totalRevenue = value; }
        public string TotalRevenueEntreprise { get => totalRevenueEntreprise; set => totalRevenueEntreprise = value; }
        public double PrixTrajet { get => prixTrajet; set => prixTrajet = value; }
        public int Nombre_Place_Initiales { get => nombre_Place_Initiales; set => nombre_Place_Initiales = value; }

        public override string ToString()
        {
            return num_Trajet + " " + ville_Depart + " " + ville_Arrivee + " " /*+ heure_Depart + " " + heure_Arrivee*/ + " " + date_Trajet + " " +
           prix_Trajet + " " + arret + " " + nombre_Place_dispo + " " + etat + " " + num_Conducteur + " " + heureDepartString + " " + heureArriveeString + " " + nom_Conducteur + " " + prenom_Conducteur + " " + num_tel_Conducteur + " " + conducteur + " " + montant_total + " " + montant_compagnie
           + " " + montant_chauffeur + " " + totalRevenue + " " + totalRevenueEntreprise + " " + prixTrajet + " " + nombre_Place_Initiales;
        }

        public string exportationCSV()
        {
            return num_Trajet + "; " + Ville_Depart + ";" + ville_Arrivee + ";" + date_Trajet + ";" + prixTrajet + ";" + etat;
        }





    }

}
