using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ProjetFinal
{
    internal class Singleton
    {

        class GestionBD
        {
            MySqlConnection con;
            static GestionBD gestionBD = null;

            public GestionBD()
            {
                this.con = new MySqlConnection("Server=cours.cegep3r.info; Database=a2022_420326ri_eq17; Uid=root; Pwd=;");

            }

            public static GestionBD getInstance()
            {
                if (gestionBD == null)
                    gestionBD = new GestionBD();

                return gestionBD;
            }


        }
    }
}
