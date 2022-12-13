using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Trajet
    {
      
        String villeDepart;
        String villeArrive;
        String heureDepart;
        String heureArrive;
        String dateTrajet;
        double prix_Trajet;
        String arret;
        String etat;
        String numConducteur;
        int nombre_Place_Dispo;
        int nombre_Place_Initiales;

       

        public Trajet()
        {
         
            this.villeDepart = "";
            this.villeArrive = "";
            this.heureDepart = "";
            this.heureArrive = "";
            this.dateTrajet = "";
            this.prix_Trajet = 0;
            this.arret = "";
            this.etat = "";
            this.numConducteur = "";
            this.nombre_Place_Dispo= 0;
            this.nombre_Place_Initiales= 0;

        }

        public Trajet( string _villeDepart, String _villeArrive, string _heureDepart, string _heureArrive, string _dateTrajet, double _prixTrajet, string _arret, string _etat, string _numConducteur, int _nombre_Place_Dispo, int _nombre_Place_Initiales)
        {
         
            this.villeDepart = _villeDepart;
            this.villeArrive = _villeArrive;
            this.dateTrajet = _dateTrajet;
            this.heureDepart = _heureDepart;
            this.heureArrive = _heureArrive;
            this.prix_Trajet = _prixTrajet;
            this.arret = _arret;
            this.etat = _etat;
            this.numConducteur= _numConducteur;
            this.nombre_Place_Dispo= _nombre_Place_Dispo;
            this.nombre_Place_Initiales= _nombre_Place_Initiales;
        }

     
        public string VilleDepart { get => villeDepart; set => villeDepart = value; }
        public string VilleArrive { get => villeArrive; set => villeArrive = value; }

        public string DateTimedateTrajet { get => dateTrajet; set => dateTrajet = value; }

        public string HeureDepart { get => heureDepart; set => heureDepart = value; } 

        public string HeureArrive { get => heureArrive; set => heureArrive = value; } 

        public double PrixTrajet { get => prix_Trajet; set=> prix_Trajet = value; }

        public string Arret { get => arret; set=> arret = value; }

        public string Etat { get => etat; set => etat = value; }

        public string NumConducteur { get => numConducteur; set => numConducteur = value; }

        public int NombrePlaceDispo { get => nombre_Place_Dispo; set => nombre_Place_Dispo = value; }

        public int Nombre_Place_Initiales { get => nombre_Place_Initiales; set => nombre_Place_Initiales = value; }







        public override string ToString()
        {
            return  villeDepart + " " + villeArrive + " " + heureDepart + " " + heureArrive + ""  + prix_Trajet + " " + arret +" "+etat+" "+numConducteur+ " "+nombre_Place_Dispo+" "+nombre_Place_Initiales;
        }



    }
}
