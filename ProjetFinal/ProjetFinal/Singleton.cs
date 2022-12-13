using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;
using MySqlX.XDevAPI;

namespace ProjetFinal
{
    internal class Singleton
    {


        MySqlConnection con;
        static Singleton singleton = null;
        ObservableCollection<Trajet>listeTrajet;
        ObservableCollection<Client>listeClient;
        int idChauffeur;

        public int IdChauffeur { get => idChauffeur; set => idChauffeur = value; }

        public Singleton()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info; Database=a2022_420326ri_eq17; Uid=2103279; Pwd=2103279");

            listeTrajet = new ObservableCollection<Trajet>();

        }

        public static Singleton getInstance()
        {
            if (singleton == null)
                singleton = new Singleton();

            return singleton;
        }

        public void AjouterChauffeur(string nom, string prenom, string adresse, string email, string numero, string numCompagnie, String motDePasse)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into conducteur(nom_Conducteur,prenom_Conducteur,adresse_Conducteur,email_Conducteur,num_Telephone,num_Compagnie,mot_de_Passe) values(@nom,@prenom,@adresse,@email,@numero,@numCompagnie,@motDePasse)";


                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
                commande.Parameters.AddWithValue("@adresse", adresse);
                commande.Parameters.AddWithValue("@email", email);
                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@numCompagnie", numCompagnie);
                commande.Parameters.AddWithValue("@motDePasse", motDePasse);


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

        public void AjouterTrajet( String villeDepart, string villeArrive, string heureDepart, string heureArrive, string dateTrajet, double prixTrajet, string arret, string etat, string numConducteur, int nombrePlaceDispo, int nombrePlaceInitiales)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into trajet(ville_Depart,ville_Arrivee,heure_Depart,heure_Arrivee,date_Trajet,prix_Trajet,arret,etat,num_Conducteur,nombre_Place_dispo,nombre_Place_initales) " +
                    "values(@villeDepart,@villeArrive,@heureDepart,@heureArrive,@dateTrajet, @prixTrajet, @arret, @etat, @numConducteur, @nombrePlaceDispo, @nombrePlaceInitiales)";

                commande.Parameters.AddWithValue("@villeDepart", villeDepart);
                commande.Parameters.AddWithValue("@villeArrive", villeArrive);
                commande.Parameters.AddWithValue("@heureDepart", heureDepart);
                commande.Parameters.AddWithValue("@heureArrive", heureArrive);
                commande.Parameters.AddWithValue("@dateTrajet", dateTrajet);
                commande.Parameters.AddWithValue("@prixTrajet", prixTrajet);
                commande.Parameters.AddWithValue("@arret", arret);
                commande.Parameters.AddWithValue("@etat", etat);
                commande.Parameters.AddWithValue("@numConducteur", numConducteur);
                commande.Parameters.AddWithValue("@nombrePlaceDispo", nombrePlaceDispo);
                commande.Parameters.AddWithValue("@nombrePlaceInitiales", nombrePlaceInitiales);

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

        public ObservableCollection<Trajet>AfficheTrajet(string numconducteur)
        {
            listeTrajet.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("historiqueTrajet");
                commande.Connection= con;
                commande.CommandType= System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@numconducteur",numconducteur);
           
                con.Open();

                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();


                while(r.Read())
                {
                    listeTrajet.Add(new Trajet()
                    {
                        VilleDepart = r.GetString(1),
                        VilleArrive= r.GetString(2),
                        HeureDepart = r.GetString(3),
                        HeureArrive= r.GetString(4),
                        Arret = r.GetString(7),
                        NombrePlaceDispo = r.GetInt32(10),
                        Nombre_Place_Initiales = r.GetInt32(11)                   
                    });
                }
                r.Close();
                con.Close();
            }

            catch(MySqlException ex)
            {
                if(con.State == System.Data.ConnectionState.Open) 
                    con.Close();
            }

            return listeTrajet;
        }




        public Boolean connexionChauff(string email, string password)
        {
            con.Close();

            bool ok = false;


            MySqlCommand commande = new MySqlCommand("ConnexionChauffeur");
            commande.Connection = con;// indique le chemin à commande
            commande.CommandType = System.Data.CommandType.StoredProcedure;// ce qu,il faut aller chercher
            commande.Parameters.AddWithValue("@emailCond", email);
            commande.Parameters.AddWithValue("@motDePasseCond", password);



            con.Open();// ouvre la connection
            //commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
            int i = commande.ExecuteNonQuery();
            MySqlDataReader r = commande.ExecuteReader();


            if (r.Read())
            {
                idChauffeur = r.GetInt32("num_Conducteur");
                ok = true;
            }
            return ok;

        }


        public ObservableCollection<Client> NomPrenomClient(string numTrajet)
        {
            listeClient.Clear();

            try
            {
                MySqlCommand commande = new MySqlCommand("nomEtPrenom");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@numTrajet", numTrajet);

                con.Open();

                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();


                while (r.Read())
                {
                    listeClient.Add(new Client()
                    {
                      Nom_Client = r.GetString(2),
                      Prenom_Client = r.GetString(3),
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

            return listeClient;
        }


    }
}
