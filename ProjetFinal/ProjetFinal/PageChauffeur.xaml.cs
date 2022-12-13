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
    public sealed partial class PageChauffeur : Page
    {
        public PageChauffeur()
        {
            this.InitializeComponent();
        }
        private void btAjoutTrajet_Click(object sender, RoutedEventArgs e)
        {
            //  DateTime d = new DateTime();
            //  TimeSpan t = new TimeSpan();
            double p = 0;
            int np = 0;

            int valide = 0;


            if (tbxVilleDepart.Text.Trim() == "")
            {
                ErrVilleDepart.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxVilleArrive.Text.Trim() == "")
            {
                ErrVilleArrive.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxPrixTrajet.Text.Trim() == "")
            {
                ErrPrixTrajet.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxArret.Text.Trim() == "")
            {
                ErrArret.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxEtat.Text.Trim() == "")
            {
                ErrEtat.Visibility = Visibility.Visible;
                valide += 1;
            }
            if (tbxNumConducteur.Text.Trim() == "")
            {
                ErrNumConducteur.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxNombrePlaceDispo.Text.Trim() == "")
            {
                ErrNombrePlaceDispo.Visibility = Visibility.Visible;
                valide += 1;
            }

            if (tbxNombrePlaceInitiales.Text.Trim() == "")
            {
                ErrNombrePlaceInitiales.Visibility = Visibility.Visible;
                valide += 1;
            }
            else
            {
                ErrNombrePlaceInitiales.Visibility = Visibility.Collapsed;

            }



            //  t = tbxheureDepart.Time.value.ToString();






            //  try
            // {
            //   d = calendar.Date.Value.Date;
            //}
            //catch (InvalidOperationException ex)
            //{
            //  ErrDateTrajet.Visibility = Visibility.Visible;
            //valide += 1;
            //}

            if (valide == 0)
            {
                GestionBD.getInstance().AjouterTrajet(tbxVilleDepart.Text, tbxVilleArrive.Text, tbxheureDepart.Time.ToString(), tbxheureArrive.Time.ToString(), calandar.Date.Value.ToString("yyyyy-MM-dd"), p, tbxArret.Text, tbxEtat.Text, tbxNumConducteur.Text, np, np);
                formTrajet.Visibility = Visibility.Collapsed;
                validation.Visibility = Visibility.Visible;

            }

        }

        private void HistoriqueTrajet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
