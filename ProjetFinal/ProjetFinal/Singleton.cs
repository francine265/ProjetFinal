using MySql.Data.MySqlClient;
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
        ObservableCollection<Trajet> liste;
        static Singleton singleton = null;  // creation et initialisation d'un objet static gestionBD de la class GestionBD

        public Singleton()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq1;Uid=2100781;Pwd=2100781;");
            liste = new ObservableCollection<Trajet>();
        }
        public static Singleton getInstance()
        {
            if (singleton == null)
                singleton = new Singleton();

            return singleton;
        }


        public ObservableCollection<Trajet> GetTrajets()
        {
            liste.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from trajet";
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {


                    liste.Add(new Trajet()
                    {
                        //Id = (int)r.GetInt32(0),
                        //Nom = r.GetString(1),
                        //Prenom = r.GetString(2),
                        //Email = r.GetString(3),
                    });


                    //lvliste.Items. System.Threading.Thread.Sleep(100);Add(r["id"] + " " + r["nom"] + " "+ r["prenom"] + " " + r["email"]);
                }

                r.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

            }
            return liste;

        }

        public void Ajouterville(string choixville)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;

                commande.CommandText = "insert into compagnie values(@choixville) ";

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
