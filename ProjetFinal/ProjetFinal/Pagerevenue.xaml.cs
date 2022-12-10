using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pagerevenue : Page
    {
        public Pagerevenue()
        {
            this.InitializeComponent();
        }

        private void revenue_Click(object sender, RoutedEventArgs e)
        {
            DateTime d5 = new DateTime();
            DateTime d6 = new DateTime();
            int valide = 0;


            try
            {

                d5 = calender5.Date.Value.DateTime;


            }
            catch (InvalidOperationException ex)
            {
                erreurcalender5.Visibility = Visibility.Visible;
                valide += 1;
            }

            try
            {

                d6 = calender6.Date.Value.DateTime;

            }
            catch (InvalidOperationException ex)
            {
                erreurcalender6.Visibility = Visibility.Visible;
                valide += 1;
            }



            if (valide == 0)
            {
                lvMontant.ItemsSource = Singleton.getInstance().MotantTotalSociete(d5, d6);
                lvliste.ItemsSource =Singleton.getInstance().Montant(d5,d6);
            }


        }
    }
}
