using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Connexion : Page
    {
        public Connexion()
        {
            this.InitializeComponent();
          //  conn.Visibility = Visibility.Visible;
        }

        private void seConnecter_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            if (email.Text == "")
            {
                erreuremail.Visibility = Visibility.Visible;
                valide += 1;
            }
            if(epassword.Text=="")
            {
                valide += 1;
                erreurpassword.Visibility = Visibility.Visible;
            }
            if (valide == 0)
            {
                if(GestionBD.getInstance().connexionClient(email.Text, epassword.Text)==true)
                {

                }
                //GestionBD.getInstance().connexionClient(email.Text,epassword.Text);

            }
        }
    }
}
