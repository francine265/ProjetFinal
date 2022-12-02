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
        ObservableCollection<Trajets> lvliste;// pas automatique , on le fait car on fera un select de liste plustard
        static GestionBD gestionBD = null;// ce qui crée le singleton pour avoir un seul objet à utiliser
        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq17;Uid=2014985;Pwd=2014985;");
            lvliste = new ObservableCollection<Trajets>();

        }
        public static GestionBD getInstance()// rapport avec le singleton
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
        public ObservableCollection<Trajets> GetTrajets()
        {
            try
            {
                lvliste.Clear();// pour vider la liste

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;// indique le chemin à commande 
              

                commande.CommandText = "Select * from trajet";// ce qu,il faut aller chercher

                con.Open();// ouvre la connection 
                MySqlDataReader r = commande.ExecuteReader();// permet de lire le retour qui ewst stocké dans r
               // r.Read();
                // tblTexte.Text = r["nom"].ToString();// ici nom aurait pu etre remplacé par un nombre(position ou numero de colonne) ici on a indiqué le nom de colonne
               
                while (r.Read())// read renvoie un booleen donc tant que ca renvoi quelque chose
                {
                   //  DateTime d = new DateTime();
                String d1 = r.GetString("heure_Depart");
                  String d2= r.GetString("heure_Arrivee");

                    //d.AddHours(d1.Hour);
                    // d.AddMinutes(d1.Minute);
                    // d.AddSeconds(d1.Second);

                   // DateTime d2 = new DateTime();
               // DateTime Arrive = r.GetDateTime("heure_Arrivee");

              //  d2.AddHours(Arrive.Hour);
               /* d2.AddMinutes(Arrive.Minute);
                d2.AddSeconds(Arrive.Second);*/

                DateTime date = new DateTime();
                DateTime dateTrajet = r.GetDateTime("date_Trajet");

                date.AddYears(dateTrajet.Year);
                date.AddMonths(dateTrajet.Month);
                date.AddDays(dateTrajet.Day);
                    lvliste.Add(new Trajets()// car la classe Trajets n'a pas de constructeur(voir cours)
                    {


                        Num_Trajet= (int)r["num_Trajet"],
                        Ville_Depart = r.GetString(1),
                        Ville_Arrivee = r.GetString(2),
                        HeureDepartString = d1,
                        HeureArriveeString = d2,
                       Date_Trajet= date,
                        Prix_Trajet=r.GetDouble(6),
                        Arret= r.GetString(7),
                        Nombre_Place_dispo= (int)r["nombre_Place_dispo"],
                        Etat= r.GetString(9),
                        Num_Conducteur= (int)r["num_Conducteur"],
                    });
       
                }

                r.Close();
                con.Close();

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return lvliste;
        }

    }
}
