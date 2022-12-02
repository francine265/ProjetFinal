using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        double prix_Trajet;
        String heureDepartString;
        String heureArriveeString;
        String arret;
        int nombre_Place_dispo;
        String etat;
        int num_Conducteur;



        public Trajets()
        {
            this.num_Trajet = 0;
            this.ville_Depart = "";
            this.ville_Arrivee = "";
            /*this.heure_Depart = new DateTime();
            this.heure_Arrivee = new DateTime();*/
            this.HeureArriveeString = "";
            this.HeureDepartString = "";
            this.date_Trajet = "";
            this.prix_Trajet = 0;
            this.arret = "";
            this.nombre_Place_dispo = 0;
            this.etat = "";
            this.num_Conducteur = 0;
        }



        public Trajets(int num_Trajet, string ville_Depart, string ville_Arrivee, string _adebut, double prix_Trajet, string arret, int nombre_Place_dispo, string etat, int num_Conducteur, String _heureDepartString,
        String _heureArriveeString)
        {
            this.num_Trajet = num_Trajet;
            this.ville_Depart = ville_Depart;
            this.ville_Arrivee = ville_Arrivee;
            /*this.heure_Depart = new DateTime( hour, minute,second);
            this.heure_Arrivee = new DateTime(_hour, _minute, _second); */
            this.date_Trajet = "";
            this.prix_Trajet = prix_Trajet;
            this.arret = arret;
            this.nombre_Place_dispo = nombre_Place_dispo;
            this.etat = etat;
            this.num_Conducteur = num_Conducteur;
            this.HeureDepartString = _heureDepartString;
            this.HeureArriveeString = _heureArriveeString;
        }



        public int Num_Trajet { get => num_Trajet; set => num_Trajet = value; }
        public string Ville_Depart { get => ville_Depart; set => ville_Depart = value; }
        public string Ville_Arrivee { get => ville_Arrivee; set => ville_Arrivee = value; }
        /*  public DateTime Heure_Depart { get => heure_Depart; set => heure_Depart = value; }
          public DateTime Heure_Arrivee { get => heure_Arrivee; set => heure_Arrivee = value; }*/
        public String Date_Trajet { get => date_Trajet; set => date_Trajet = value; }
        public double Prix_Trajet { get => prix_Trajet; set => prix_Trajet = value; }



        public String Arret { get => arret; set => arret = value; }
        public int Nombre_Place_dispo { get => nombre_Place_dispo; set => nombre_Place_dispo = value; }
        public String Etat { get => etat; set => etat = value; }
        public int Num_Conducteur { get => num_Conducteur; set => num_Conducteur = value; }
        public string HeureDepartString { get => heureDepartString; set => heureDepartString = value; }
        public string HeureArriveeString { get => heureArriveeString; set => heureArriveeString = value; }



        public override string ToString()
        {
            return num_Trajet + " " + ville_Depart + " " + ville_Arrivee + " " /*+ heure_Depart + " " + heure_Arrivee*/ + " " + date_Trajet + " " +
           prix_Trajet + " " + arret + " " + nombre_Place_dispo + " " + etat + " " + num_Conducteur + " " + heureDepartString + " " + heureArriveeString;
        }





        /*   create table Trajet(
        num_Trajet int auto_increment primary key,
        ville_Depart varchar(80),
        ville_Arrivee varchar(80),
        heure_Depart time,
        heure_Arrivee time,
        date_Trajet date,
        prix_Trajet double,
        arret varchar(90),
        nombre_Place_dispo int,
        etat varchar(80),
        num_Conducteur int ,
     foreign key(num_Conducteur) references conducteur(num_Conducteur)*/



    }
}
