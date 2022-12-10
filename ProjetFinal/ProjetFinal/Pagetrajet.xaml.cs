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
    public sealed partial class Pagetrajet : Page
    {
        public Pagetrajet()
        {
            this.InitializeComponent();
        }

        private void trajet_Click(object sender, RoutedEventArgs e)
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

        private void ecritureCSV_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

