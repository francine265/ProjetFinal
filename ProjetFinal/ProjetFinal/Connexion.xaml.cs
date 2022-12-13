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
using System.Security.Cryptography;

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
            if(epassword.Password=="")
            {
                valide += 1;
                erreurpassword.Visibility = Visibility.Visible;
            }
            if (valide == 0)

            {
               
                if(GestionBD.getInstance().connexionClient(email.Text, epassword.Password)==true)
                {
                    GestionBD.getInstance().NviAdmin.Visibility = Visibility.Collapsed;
                    GestionBD.getInstance().NviClient.Visibility = Visibility.Collapsed;
                    GestionBD.getInstance().NviChauffeur.Visibility = Visibility.Collapsed;
                    GestionBD.getInstance().NviDeConnexion.Visibility = Visibility.Visible;
                    GestionBD.getInstance().NviConnexion.Visibility = Visibility.Collapsed;
                    
                    this.Frame.Navigate(typeof(PageClient));
                }
                else
                {
                    erreuremailpass.Visibility=Visibility.Visible;
                }
                
                //GestionBD.getInstance().connexionClient(email.Text,epassword.Text);

            }
        }

        private void einscription_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(creationClient));
        }

    }
}
