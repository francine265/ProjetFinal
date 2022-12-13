using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Trajet> liste;// pas automatique , on le fait car on fera un select de liste plustard
        static GestionBD gestionBD = null;// ce qui crée le singleton pour avoir un seul objet à utiliser
        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_gr2_2014985-sorelle-francine-matho-ngoualadjo;Uid=2014985;Pwd=2014985;");
            liste = new ObservableCollection<Trajet>();

        }
        public static GestionBD getInstance()// rapport avec le singleton
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
     //   public ObservableCollection<Trajets> GetTrajets()
       // {
         //   try
           // {
             //   liste.Clear();// pour vider la liste
             //
               // MySqlCommand commande = new MySqlCommand();
                //commande.Connection = con;// indique le chemin à commande 
                //commande.CommandText = "Select * from trajet";// ce qu,il faut aller chercher

                //con.Open();// ouvre la connection 
                //MySqlDataReader r = commande.ExecuteReader();// permet de lire le retour qui ewst stocké dans r
                //r.Read();
                // tblTexte.Text = r["nom"].ToString();// ici nom aurait pu etre remplacé par un nombre(position ou numero de colonne) ici on a indiqué le nom de colonne

               // while (r.Read())// read renvoie un booleen donc tant que ca renvoi quelque chose
                //{
                  //  liste.Add(new Trajets()// car la classe Trajets n'a pas de constructeur(voir cours)
                    //{
                      //  Num_Trajet= (int)r["id"],
                        //Ville_Depart = r.GetString(1),
                        //Ville_Arrivee = r.GetString(2),
                        //Heure_Depart = r.GetTimeSpan(3),
                        //Heure_Arrivee= r.GetTime(4),
                        //Date_Trajet= r.GetString(5),
                        //Prix_Trajet=r.GetDouble(6),
                        //Arret= r.GetString(7),
                        //Nombre_Place_dispo= (int)r["nombre_Place_dispo"],
                        //Etat= r.GetString(9),
                        //Num_Conducteur= (int)r["num_Conducteur"],
                    //});
                    /*    int num_Trajet;
        String ville_Depart;
        String ville_Arrivee;
        Time heure_Depart;
        Time heure_Arrivee;
        String date_Trajet;
        double prix_Trajet;
        String arret;
        int nombre_Place_dispo;
        String etat;
        int num_Conducteur;*/
                    //System.Threading.Thread.Sleep(1000); // pour faire une pause pendant 1 seconde
                    //lvListe.Items.Add(r["id"] + " " + r["nom"] + " " + r["prenom"]);// pour l'id on pourrait aussi r.getint32(0) pour afficher l'id
            //    }

              //  r.Close();
                //con.Close();

            //}
            //catch (MySqlException ex)
            //{
              //  if (con.State == System.Data.ConnectionState.Open)
                //    con.Close();
            //}
            //return liste;
        //}

    }
}
