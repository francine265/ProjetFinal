﻿using Org.BouncyCastle.Asn1.X509;
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
        Time heure_Depart;
        Time heure_Arrivee;
        String date_Trajet;
        double prix_Trajet;
        String arret;
        int nombre_Place_dispo;
        String etat;
        int num_Conducteur;

        public int Num_Trajet { get => num_Trajet; set => num_Trajet = value; }
        public string Ville_Depart { get => ville_Depart; set => ville_Depart = value; }
        public string Ville_Arrivee { get => ville_Arrivee; set => ville_Arrivee = value; }
        public Time Heure_Depart { get => heure_Depart; set => heure_Depart = value; }
        public Time Heure_Arrivee { get => heure_Arrivee; set => heure_Arrivee = value; }
        public string Date_Trajet { get => date_Trajet; set => date_Trajet = value; }
        public double Prix_Trajet { get => prix_Trajet; set => prix_Trajet = value; }

        public String Arret { get => arret; set => arret = value; }
        public int Nombre_Place_dispo { get => nombre_Place_dispo; set => nombre_Place_dispo = value; }
        public String Etat { get => etat; set => etat = value; }
        public int Num_Conducteur { get => num_Conducteur; set => num_Conducteur = value; }

        public override string ToString()
        {
            return num_Trajet + " " + ville_Depart + " " + ville_Arrivee + " " + heure_Depart + " " + heure_Arrivee + " " + date_Trajet+" "+
           prix_Trajet+" "+ arret+" "+ nombre_Place_dispo+" "+ etat+" "+ num_Conducteur;
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