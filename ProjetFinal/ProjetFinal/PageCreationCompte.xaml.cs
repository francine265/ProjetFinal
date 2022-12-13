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
    public sealed partial class PageCreationCompte : Page
    {
        public PageCreationCompte()
        {
            this.InitializeComponent();
      
        }
       

      

       
        private void rbConnexion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rbConnexion.SelectedIndex == 0)
            {
                headerFormulaire.Text = "Remplissez le formulaire pour créer votre compte client: ";
                formClient.Visibility = Visibility.Visible;
                formChauffeur.Visibility = Visibility.Collapsed;


            }
            if (rbConnexion.SelectedIndex == 1)
            {
                headerFormulaire.Text = "Remplissez le formulaire pour créer votre compte chauffeur:";
                formChauffeur.Visibility = Visibility.Visible;
                formClient.Visibility = Visibility.Collapsed;


            }

            if (rbConnexion.SelectedIndex == 2)
            {
                headerFormulaire.Text = "Remplissez le formulaire pour créer votre compte D'Administrateur:";
                formAdmin.Visibility = Visibility.Visible;
                formClient.Visibility = Visibility.Collapsed;
                formChauffeur.Visibility = Visibility.Collapsed;


            }
        }



        private void btn_Click(object sender, RoutedEventArgs e)
        {

            int valide = 0;

            if (tbxNomClient.Text.Trim() == "")
            {


                erreurnom.Visibility = Visibility.Visible;
                valide += 1;

            }

            if (tbxPrenomClient.Text.Trim() == "")
            {


                erreurprenom.Visibility = Visibility.Visible;
                valide += 1;

            }
            if (tbxEmailClient.Text.Trim() == "")
            {


                erreurEmail.Visibility = Visibility.Visible;
                valide += 1;

            }
            if (tbxpasswordClient.Text.Trim() == "")
            {


                erreurpwd.Visibility = Visibility.Visible;
                valide += 1;

            }
            if (tbxAdresseClient.Text.Trim() == "")
            {


                erreuraddresse.Visibility = Visibility.Visible;
                valide += 1;

            }
            if (tbxTelephoneClient.Text.Trim() == "")
            {


                erreurphone.Visibility = Visibility.Visible;
                valide += 1;

            }

            if (valide == 0)
            {
               GestionBD.getInstance().AjouterClient(tbxNomClient.Text, tbxPrenomClient.Text, tbxAdresseClient.Text, tbxEmailClient.Text, tbxTelephoneClient.Text, tbxpasswordClient.Text);
                ajoutclient.Visibility = Visibility.Visible;
            }

        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            if (tbxEmail.Text.Trim() == "")
            {


                errmail.Visibility = Visibility.Visible;
                valide += 1;

            }
            if (tbxpasswordAmin.Text.Trim() == "")
            {


                erreurpwdad.Visibility = Visibility.Visible;
                valide += 1;

            }

            if (valide == 0)
            {
               GestionBD.getInstance().AjouterClient(tbxNomClient.Text, tbxPrenomClient.Text, tbxAdresseClient.Text, tbxEmailClient.Text, tbxTelephoneClient.Text, tbxpasswordClient.Text);
                ajoutadmin.Visibility = Visibility.Visible;

            }


            GestionBD.getInstance().AjoutAdmin(tbxEmail.Text, tbxpasswordAmin.Text);


        }

        private void ajoutChauffeur_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;

            if (tbxNomChauffeur.Text.Trim() == "")
            {
                ErrNomChauffeur.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxPrenomChauffeur.Text.Trim() == "")
            {
                ErrPrenomChauffeur.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxAdresseChauffeur.Text.Trim() == "")
            {
                ErrAdresseChauffeur.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxNumeroChauffeur.Text.Trim() == "")
            {
                ErrNumeroChauffeur.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxEmailChauffeur.Text.Trim() == "")
            {
                ErrEmailChauffeur.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxMotDePasse.Text.Trim() == "")
            {
                ErrMotDePasse.Visibility = Visibility.Visible;
                valide += 1;
            }

            //   string expression = "^\\(\\d{ 3}\\)\\d{ 3}-\\d{ 4}$";

            // if (Regex.IsMatch(tbxNumeroChauffeur.Text, expression) == false)
            //{
            //  ErrNumeroChauffeur.Visibility = Visibility.Visible;
            //ErrNumeroChauffeur.Text = "Veuillez respecter le format de numéro de téléphone";
            //  valide += 1;
            //}

            if (valide == 0)
            {
               GestionBD.getInstance().AjouterChauffeur(tbxNomChauffeur.Text, tbxPrenomChauffeur.Text, tbxAdresseChauffeur.Text, tbxEmailChauffeur.Text, tbxNumeroChauffeur.Text, tbxNumCompagnie.Text, tbxMotDePasse.Text);
                formChauffeur.Visibility = Visibility.Collapsed;
                validation.Visibility = Visibility.Visible;

            }

        }
    }
}
