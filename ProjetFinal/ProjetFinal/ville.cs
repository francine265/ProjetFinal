using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class ville
    {


        String choixville;
       
        public ville()
        {
            this.choixville = "";
            
        }

        public ville(string choixville)
        {
            this.choixville = choixville;
        }

        public string Choixville { get => choixville; set => choixville = value; }

        public override string ToString()
        {
            return choixville ;
        }


    }
}
