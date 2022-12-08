using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        ObservableCollection<Trajets> listeAffichetrajetdateT;
        ObservableCollection<Trajets> listeAffichetrajetdate;
        ObservableCollection<Trajets> listeMontantTotal;
        static Singleton singleton = null;  // creation et initialisation d'un objet static gestionBD de la class GestionBD

        public Singleton()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq17;Uid=2014985;Pwd=2014985;");
            listeTrajetsencours = new ObservableCollection<Trajets>();
            listeAffichetrajetdateT = new ObservableCollection<Trajets>();
            listeAffichetrajetdate = new ObservableCollection<Trajets>();
            listeMontantTotal= new ObservableCollection<Trajets>();
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
                       Nombre_Place_dispo=r.GetInt32(10),
                        Etat =r.GetString(8),
                    Num_Conducteur =r.GetInt32(9)
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


        public ObservableCollection<Trajets> GetTrajetsdate(DateTime date1 , DateTime date2)
        {
            listeAffichetrajetdateT.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand("Affiche_trajet_date");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@date1" ,date1.ToString("yyyy-MM-dd"));
                commande.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));


                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();
               // r.Read();
                while (r.Read())
                {



                    listeAffichetrajetdateT.Add(new Trajets()
                    {
                        Num_Trajet = r.GetInt32(0),
                        Ville_Depart = r.GetString(1),
                        Ville_Arrivee = r.GetString(2),
                        HeureDepartString = r.GetString("heure_Depart"),
                        HeureArriveeString = r.GetString("heure_Arrivee"),
                        Date_Trajet = r.GetString("date_Trajet"),
                        Prix_Trajet = r.GetInt32(6),
                        Arret = r.GetString(7),
                        Nombre_Place_dispo = r.GetInt32(10),
                        Etat = r.GetString(8),
                        Num_Conducteur = r.GetInt32(9)
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
            return listeAffichetrajetdateT;

        }


        public void Ajouterville(string choixville , string email ,string password)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
               
                commande.CommandText = "insert into administrateur values(null,@email,@choixville ,@password) ";

              
                commande.Parameters.AddWithValue("@email", email);
                commande.Parameters.AddWithValue("@choixville", choixville);
                commande.Parameters.AddWithValue("@password", password);


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

        public ObservableCollection<Trajets> Montant(DateTime date1, DateTime date2)
        {
            listeAffichetrajetdate.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand("Revenue_entreprise");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
                commande.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();
             

                while (r.Read())
                {


                    listeAffichetrajetdate.Add(new Trajets()
                    {
                        Num_Trajet = r.GetInt32(0),
                        
                        Ville_Depart = r.GetString(1),
                        Ville_Arrivee = r.GetString(2),
                        Conducteur = r.GetString(3),
                        Montant_total = r.GetInt32(4),
                        Montant_chauffeur = r.GetInt32(5),
                        Montant_compagnie = r.GetInt32(6),

                    });

                }


                con.Close();

            }
            catch (MySqlException ex)
            {
                con.Close();
            }
            return listeAffichetrajetdate;

        }



        public ObservableCollection<Trajets> MotantTotalSociete(DateTime date1, DateTime date2)
        {
            listeMontantTotal.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand("Revenue_Total_entreprise");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
                commande.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();


                while (r.Read())
                {


                    listeMontantTotal.Add(new Trajets()
                    {
                        TotalRevenueEntreprise = r.GetString(0),
                    });

                }


                con.Close();

            }
            catch (MySqlException ex)
            {
                con.Close();
            }
            return listeMontantTotal;

        }





    }
}
