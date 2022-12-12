using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using Microsoft.UI.Xaml;

namespace ProjetFinal
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Trajets> listeTrajetsencours;
        ObservableCollection<Trajets> listeAffichetrajetdateT;
        ObservableCollection<Trajets> listeAffichetrajetdate;
        ObservableCollection<Trajets> listeMontantTotal;
        Window fenetre;
        ObservableCollection<Trajets> lvliste;// pas automatique , on le fait car on fera un select de liste plustard
        static GestionBD gestionBD = null;// ce qui crée le singleton pour avoir un seul objet à utiliser

        NavigationViewItem nviAdmin;
        NavigationViewItem nviChauffeur;
        NavigationViewItem nviClient;
        NavigationViewItem nviDeConnexion;
        NavigationViewItem nvinom;
        NavigationViewItem nviConnexion;


        int idUtilisateur;
        string nom, prenom;


        public Window Fenetre { get => fenetre; set => fenetre = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        internal ObservableCollection<Trajets> Lvliste { get => lvliste;  }
        public NavigationViewItem NviAdmin { get => nviAdmin; set => nviAdmin = value; }
        public NavigationViewItem NviChauffeur { get => nviChauffeur; set => nviChauffeur = value; }
        public NavigationViewItem NviClient { get => nviClient; set => nviClient = value; }
        public NavigationViewItem NviDeConnexion { get => nviDeConnexion; set => nviDeConnexion = value; }
        public NavigationViewItem Nvinom { get => nvinom; set => nvinom = value; }
        public NavigationViewItem NviConnexion { get => nviConnexion; set => nviConnexion = value; }

        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq17;Uid=2014985;Pwd=2014985;");
            lvliste = new ObservableCollection<Trajets>();
            listeTrajetsencours = new ObservableCollection<Trajets>();
            listeAffichetrajetdateT = new ObservableCollection<Trajets>();
            listeAffichetrajetdate = new ObservableCollection<Trajets>();
            listeMontantTotal = new ObservableCollection<Trajets>();

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

            bool ok = false;

            MySqlCommand commande = new MySqlCommand("connexionClient");
            commande.Connection = con;// indique le chemin à commande 
            commande.CommandType = System.Data.CommandType.StoredProcedure;// ce qu,il faut aller chercher
            commande.Parameters.AddWithValue("@mail", emaile);
            commande.Parameters.AddWithValue("@motpass", genererSHA256( passwrd));

            con.Open();// ouvre la connection 
            //commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
            int i = commande.ExecuteNonQuery();
            MySqlDataReader r = commande.ExecuteReader();
            
            if(r.Read())
            {
                idUtilisateur = r.GetInt32("num_client");
                nom = r.GetString("nom_Client");
                prenom = r.GetString("prenom_Client");
                //nom = r.GetString("nom_client");
                ok = true;
            }
            return ok;





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
        public ObservableCollection<Trajets> Reservationtrajet(int numTrajet)
        {

            lvliste.Clear();
            try
            {


                MySqlCommand commande = new MySqlCommand("ReserverTrajet");
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@numCl", idUtilisateur);// met l'id dans l'espace qui lui a été réservé
                commande.Parameters.AddWithValue("@numTraj", numTrajet);
             



                con.Open();// ouvre la connection 
                commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
                int i = commande.ExecuteNonQuery();
                
                
                con.Close();
            }

            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            
            return lvliste;



        }
        public long Checksouscrit( int numTrajet)
        {
            long compteur=-1;
            try
            {


                MySqlCommand commande = new MySqlCommand("Checksouscrit");
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@numCl", idUtilisateur);// met l'id dans l'espace qui lui a été réservé
                commande.Parameters.AddWithValue("@numTraj", numTrajet);




                con.Open();// ouvre la connection 
                commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
              compteur = (Int64)commande.ExecuteScalar();

                


                con.Close();
            }

            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return compteur;
        }
        public void Deconnexion()
        {
            idUtilisateur = 0;
            nom = "";
            prenom = "";
        }
        public string genererSHA256(string texte)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texte));

            StringBuilder sb = new StringBuilder();
            foreach (Byte b in bytes)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }

        public string nomPrenom()
        {
           

            return nom +" "+prenom;
        }

        public void motdepasse()
        {
            List<TempClass> list = new List<TempClass>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;// indique le chemin à commande 
            commande.CommandText = "select num_client, motdePasse from client";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while(r.Read())
            {
                list.Add(new TempClass
                {
                    Id = r.GetInt32(0),
                    Mdp = genererSHA256( r.GetString(1))
                });

               
            }

            r.Close();
            con.Close();

            foreach(TempClass tempClass in list)
            {
                MySqlCommand commande2 = new MySqlCommand();
                commande2.Connection = con;// indique le chemin à commande 
                commande2.CommandText = "update client set mdp = '" + tempClass.Mdp + "' where num_client = " + tempClass.Id;
                con.Open();
                commande2.ExecuteReader();
                con.Close();

            }


        }

        public Boolean connexionadmin(string email, string password)
        {
            con.Close();

            bool ok = false;

            MySqlCommand commande = new MySqlCommand("connexionAdmin");
            commande.Connection = con;// indique le chemin à commande
            commande.CommandType = System.Data.CommandType.StoredProcedure;// ce qu,il faut aller chercher
            commande.Parameters.AddWithValue("@mail", email);
            commande.Parameters.AddWithValue("@motpass", password);



            con.Open();// ouvre la connection
            commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
            int i = commande.ExecuteNonQuery();
            MySqlDataReader r = commande.ExecuteReader();

            if (r.Read())
            {

                //nom = r.GetString("nom_client");
                ok = true;
            }
            return ok;

        }
        public ObservableCollection<Trajets> GetTrajetsdate(DateTime date1, DateTime date2)
        {
            listeAffichetrajetdateT.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand("Affiche_trajet_date");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
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
                        PrixTrajet = r.GetInt32(6),
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

        public void AjoutAdmin(string email, string password)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;

                commande.CommandText = "insert into administrateur values(null,@email ,@password) ";


                commande.Parameters.AddWithValue("@email", email);
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

        public void Ajoutville(string choixville)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;

                commande.CommandText = "insert into ville values(@ville) ";

                commande.Parameters.AddWithValue("@ville", choixville);

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


        public void AjouterClient(string nomClient, string prenomClient, string adresse, string email, string numeroPhone, string password)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand("insertionClient");
                commande.Connection = con;

                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@nomCl", nomClient);
                commande.Parameters.AddWithValue("@prenomCl", prenomClient);
                commande.Parameters.AddWithValue("@adresseCl", adresse);
                commande.Parameters.AddWithValue("@emailCl", email);
                commande.Parameters.AddWithValue("@numCl", numeroPhone);
                commande.Parameters.AddWithValue("@motPasseCl", password);


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
            con.Close();
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
