using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
        {con.Close();
            try
            {
                lvliste.Clear();// pour vider la liste

                MySqlCommand commande = new MySqlCommand("Affiche_Trajet");
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                
               con.Open();// ouvre la connection 
                //commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();

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

            //    DateTime date = new DateTime();
               string dateTrajet = r.GetString("date_Trajet");

              //  date.AddYears(dateTrajet.Year);
              //  date.AddMonths(dateTrajet.Month);
              //  date.AddDays(dateTrajet.Day);
                    lvliste.Add(new Trajets()// car la classe Trajets n'a pas de constructeur(voir cours)
                    {


                        Num_Trajet= (int)r["num_Trajet"],
                        Ville_Depart = r.GetString(1),
                        Ville_Arrivee = r.GetString(2),
                        HeureDepartString = d1,
                        HeureArriveeString = d2,
                       Date_Trajet= dateTrajet,
                        Prix_Trajet=r.GetString(6),
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
            //con.Close();
            return lvliste;
        }
        public ObservableCollection<Trajets> RechercheTrajet(DateTime dated,string villede , string villea)
        {
            lvliste.Clear();
            try
            {


                MySqlCommand commande = new MySqlCommand("Recherche_Trajet");
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@datedeb", dated.ToString("yyyy-MM-dd"));// met l'id dans l'espace qui lui a été réservé
                commande.Parameters.AddWithValue("@villed", villede);
                commande.Parameters.AddWithValue("@villea", villea);



                con.Open();// ouvre la connection 
                commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();// permet de lire le retour qui ewst stocké dans r

                //   public static bool TryParseExact(string? s, string? format, out DateOnly result);

                while (r.Read())
                 
                {


                    /* DateOnly d = new DateOnly();
                     DateTime dateTime = r.GetDateTime("debut");

                     d.AddYears(dateTime.Year);
                     d.AddMonths(dateTime.Month);
                     d.AddDays(dateTime.Day);
 */
                    string dateTrajet1 = r.GetString("date_Trajet");
                    lvliste.Add(new Trajets()
                    {

                        Num_Trajet = (int)r["num_Trajet"],
                        Ville_Depart = r.GetString(1),
                        Ville_Arrivee = r.GetString(2),
                        HeureDepartString = r.GetString("heure_Depart"),
                        HeureArriveeString = r.GetString("heure_Arrivee"),
                        Date_Trajet = dateTrajet1,
                        Prix_Trajet = r.GetString(6),
                        Arret = r.GetString(7),
                        Nombre_Place_dispo = (int)r["nombre_Place_dispo"],
                        Etat = r.GetString(9),
                        Num_Conducteur = (int)r["num_Conducteur"],

                    });

                } 
                //if (r.Read() == false)
                //{
                //    PagePrincipale.nondispo.text
                //}

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

        public Boolean connexionClient(string emaile,string passwrd)
        {
            con.Close();

            MySqlCommand commande = new MySqlCommand("connexionClient");
            commande.Connection = con;// indique le chemin à commande 
            commande.CommandType = System.Data.CommandType.StoredProcedure;// ce qu,il faut aller chercher
            commande.Parameters.AddWithValue("@mail", emaile);
            commande.Parameters.AddWithValue("@motpass", passwrd);

            con.Open();// ouvre la connection 
            //commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
            int i = commande.ExecuteNonQuery();
            MySqlDataReader r = commande.ExecuteReader();
 

            return r.Read();





        }
        public ObservableCollection<Trajets> detailtrajet()
        {
            con.Close();

            try
            {
                lvliste.Clear();// pour vider la liste

                MySqlCommand commande = new MySqlCommand("DetailsTrajet");
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandType = System.Data.CommandType.StoredProcedure;



                con.Open();// ouvre la connection 
                //commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())// read renvoie un booleen donc tant que ca renvoi quelque chose
                {
                 
                    String d1 = r.GetString("heure_Depart");
                    String d2 = r.GetString("heure_Arrivee");
                    string dateTrajet = r.GetString("date_Trajet");

                    lvliste.Add(new Trajets()// car la classe Trajets n'a pas de constructeur(voir cours)
                    {

                        Num_Trajet = (int)r["num_Trajet"],
                        Ville_Depart = r.GetString(1),
                        Ville_Arrivee = r.GetString(2),
                        HeureDepartString = d1,
                        HeureArriveeString = d2,
                        Date_Trajet = dateTrajet,
                        Prix_Trajet = r.GetString(6),
                        Arret = r.GetString(7),
                        Nombre_Place_dispo = (int)r["nombre_Place_dispo"],
                        Etat = r.GetString(9),
                        Num_Conducteur = (int)r["num_Conducteur"],
                        Nom_Conducteur=r.GetString(11),
                        Num_tel_Conducteur=r.GetString(12),
                    
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
            //con.Close();
            return lvliste;




        }



    }
}
