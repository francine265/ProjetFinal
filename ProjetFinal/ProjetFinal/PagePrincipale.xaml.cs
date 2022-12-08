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
    public sealed partial class PagePrincipale : Page
    {
        public PagePrincipale()
        {
            this.InitializeComponent();
            GestionBD.getInstance().NviAdmin.Visibility=Visibility.Collapsed;
            GestionBD.getInstance().NviChauffeur.Visibility=Visibility.Collapsed;
            GestionBD.getInstance().NviClient.Visibility=Visibility.Collapsed;
            GestionBD.getInstance().NviDeConnexion.Visibility=Visibility.Collapsed;
            lvListe.ItemsSource= GestionBD.getInstance().GetTrajets();
        }

        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            DateTime d1= new DateTime();
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
            if( (depart.Text == "Depart") || (depart.Text==""))
            {
                valide += 1;
                erreurd.Visibility=Visibility.Visible;    

            }
            if((Arrivee.Text == "")||(Arrivee.Text== "arrivée"))
            {
                valide += 1;
                erreurA.Visibility=Visibility.Visible;
            }
        
            if (valide == 0)
            {
                //datePicker.SelectedDate = DateTimeOffset.Now;
                DateTime d = calendar1.Date.Value.DateTime;
                lvListe.ItemsSource = GestionBD.getInstance().RechercheTrajet(d, depart.Text, Arrivee.Text);
                if(lvListe.Items.Count == 0)
                {
                    nondispo.Visibility = Visibility.Visible;
                    

                }
            }

          

        }

        private void lvListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(OptionsConnexions));
        }
    }
}
