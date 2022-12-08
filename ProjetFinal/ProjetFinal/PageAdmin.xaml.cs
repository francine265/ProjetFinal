using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI.Common;
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
    public sealed partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            this.InitializeComponent();
           
           
        }

        private void btnAjoutVille_Click(object sender, RoutedEventArgs e)
        {
            //ville vi = cmb.SelectedItem as ville;

           
            DateTime d = new DateTime();
            int valide = 0;

            if (email.Text.Trim() == "")
            {


                erreuremail.Visibility = Visibility.Visible;
                valide += 1;

            }
            if (passwood.Text.Trim() == "")
            {


                erreurpassword.Visibility = Visibility.Visible;
                valide += 1;

            }

            if (cmb.SelectedValue == null)
            {


                erreurcmb.Visibility = Visibility.Visible;
                valide += 1;

            }


            if (valide == 0)
            {

                Singleton.getInstance().Ajouterville(cmb.SelectedItem.ToString(), email.Text ,passwood.Text);
                formville.Visibility = Visibility.Collapsed;
                tbl_texte.Visibility = Visibility.Visible;

            }


           
        }



        private void btn_Click(object sender, RoutedEventArgs e)
        {
            lv.ItemsSource = Singleton.getInstance().GetTrajets();
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {

            DateTime d1 = new DateTime();
            DateTime d2 = new DateTime();
            int valide = 0;


            try
            {
                /// d1 = calendar.Date.Value.Date;
                /// 
                 d1 = calender1.Date.Value.DateTime;
                

            }
            catch (InvalidOperationException ex)
            {
                erreurcalender1.Visibility = Visibility.Visible;
                valide += 1;
            }

            try
            {
                /// d1 = calendar.Date.Value.Date;
                /// 
                
                d2 = caleder2.Date.Value.DateTime;

            }
            catch (InvalidOperationException ex)
            {
                erreurcalender2.Visibility = Visibility.Visible;
                valide += 1;
            }



            if (valide == 0)
            {
                lv.ItemsSource = Singleton.getInstance().GetTrajetsdate(d1, d2);
            }
           
            //d2 = caleder2.Date.Value.DateTime;

           
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            DateTime d3 = new DateTime();
            DateTime d4 = new DateTime();
            int valide = 0;


            try
            {
               
                d3 = calender3.Date.Value.DateTime;
               

            }
            catch (InvalidOperationException ex)
            {
                erreurcalender3.Visibility = Visibility.Visible;
                valide += 1;
            }

            try
            { 

                d4 = calender4.Date.Value.DateTime;

            }
            catch (InvalidOperationException ex)
            {
                erreurcalender4.Visibility = Visibility.Visible;
                valide += 1;
            }



            if (valide == 0)
            {
                lvliste.ItemsSource = Singleton.getInstance().Montant(d3, d4);
            }
            
        }

        private void totalrevenue_Click(object sender, RoutedEventArgs e)
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
                lvMontant.ItemsSource = Singleton.getInstance().MotantTotalSociete(d5,d6);
            }
           

        }
    }
}
