using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Singleton
    {


        MySqlConnection con;
        ObservableCollection<Trajets> listeTrajetsencours;
        static Singleton singleton = null;  // creation et initialisation d'un objet static gestionBD de la class GestionBD

        public Singleton()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq17;Uid=2100781;Pwd=2100781;");
            listeTrajetsencours = new ObservableCollection<Trajets>();
        }
        public static Singleton getInstance()
        {
            if (singleton == null)
                singleton = new Singleton();

            return singleton;
        }


        public ObservableCollection<Trajets> GetTrajets()
        {
            listeTrajetsencours.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand("trajet_encours");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                //commande.CommandText = "Select * from trajet where etat = en cours";
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    String d = r.GetString("heure_Depart");
                    String d1 = r.GetString("heure_Arrivee");
                    string d2 = r.GetString("date_Trajet");

                    


                    listeTrajetsencours.Add(new Trajets()
                    {
                        Num_Trajet = r.GetInt32(0),
                        Ville_Depart =r.GetString(1),
                        Ville_Arrivee =r.GetString(2),
                        HeureDepartString = d,
                        HeureArriveeString = d1,
                       Date_Trajet =d2,
                        Prix_Trajet= r.GetInt32(6),
                        Arret =r.GetString(7),
                       Nombre_Place_dispo=r.GetInt32(8),
                        Etat =r.GetString(9),
                    Num_Conducteur =r.GetInt32(10)
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
            return listeTrajetsencours;

        }

        public void Ajouterville(string choixville , string email)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
               
                commande.CommandText = "insert into administrateur values(null,@email,@choixville) ";

              
                commande.Parameters.AddWithValue("@email", email);
                commande.Parameters.AddWithValue("@choixville", choixville);


                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();

            }
            catch (MySqlException ex)
            {
                con.Close();
            }


        }


    }
}
