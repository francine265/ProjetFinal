using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public sealed partial class PageClient : Page
    {
        public PageClient()
        {
            this.InitializeComponent();
            lvListe.ItemsSource = GestionBD.getInstance().detailtrajet();
            tbnom.Text = GestionBD.getInstance().nomPrenom();

        }

        private void lvListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


        }

        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            DateTime d1 = new DateTime();
            int valide = 0;
            try
            {
                d1 = calendar1.Date.Value.Date;
            }
            catch (InvalidOperationException ex)
            {
                erreurCalendar.Visibility = Visibility.Visible;
                valide += 1;
            }
            if ((depart.Text == "Depart") || (depart.Text == ""))
            {
                valide += 1;
                erreurd.Visibility = Visibility.Visible;

            }
            if ((Arrivee.Text == "") || (Arrivee.Text == "arrivée"))
            {
                valide += 1;
                erreurA.Visibility = Visibility.Visible;
            }

            if (valide == 0)
            {
                //datePicker.SelectedDate = DateTimeOffset.Now;
                DateTime d = calendar1.Date.Value.DateTime;
                lvListe.ItemsSource = GestionBD.getInstance().RechercheTrajet(d, depart.Text, Arrivee.Text);
                if (lvListe.Items.Count == 0)
                {
                    nondispo.Visibility = Visibility.Visible;


                }
            }



        

    }

        private async void reserver_Click(object sender, RoutedEventArgs e)
        {
            Trajets t = ((FrameworkElement)sender).DataContext as Trajets;

            if (GestionBD.getInstance().Checksouscrit(t.Num_Trajet)== 1)
            {
                ContentDialog dialog3 = new ContentDialog();
                dialog3.XamlRoot = stk.XamlRoot;
                dialog3.Title = "Attention!";
                dialog3.CloseButtonText = "Ok";
                dialog3.Content = "Vous êtes dejà inscrit à ce trajet";
                 await dialog3.ShowAsync();
                return;
            }

           

           // Button b = sender as Button;
          //  int num = Convert.ToInt32(b.Tag);



            if (t.Nombre_Place_dispo > 0)
            {


                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = stk.XamlRoot;
                dialog.Title = "Attention!";
                dialog.PrimaryButtonText = "Oui";
                dialog.SecondaryButtonText = "Non";
                dialog.CloseButtonText = "Annuler";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = "voulez-vous vraiment réserver ce trajet?";

                ContentDialogResult resultat = await dialog.ShowAsync();

                if (resultat == ContentDialogResult.Primary)
                {
                    GestionBD.getInstance().Reservationtrajet(t.Num_Trajet);
                    ContentDialog dialog2 = new ContentDialog();
                    dialog2.XamlRoot = stk.XamlRoot;
                    dialog2.Title = "Inscription au trajet Réussi!";
                    dialog2.PrimaryButtonText = "ok";
                    ContentDialogResult resultat2 = await dialog2.ShowAsync();
                    if (resultat2 == ContentDialogResult.Primary)
                    {
                        this.Frame.Navigate(typeof(PageClient));
                    }
                }
            }
            else
            {


                ContentDialog dialogindispo = new ContentDialog();
                dialogindispo.XamlRoot = stk.XamlRoot;
                dialogindispo.Title = "Desolé :( ";
                dialogindispo.PrimaryButtonText = "Ok";

                dialogindispo.DefaultButton = ContentDialogButton.Primary;
                dialogindispo.Content = "Ce trajet est dejà complet!";
                ContentDialogResult resultatindispo = await dialogindispo.ShowAsync();
                if (resultatindispo == ContentDialogResult.Primary)
                {
                    this.Frame.Navigate(typeof(PageClient));
                }
                this.Frame.Navigate(typeof(PageClient));
            }

        }

      




        
    }
}
