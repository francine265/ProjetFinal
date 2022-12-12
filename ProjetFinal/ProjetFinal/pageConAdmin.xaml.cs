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
    public sealed partial class pageConAdmin : Page
    {
        public pageConAdmin()
        {
            this.InitializeComponent();
        }
        private void connexion_Click(object sender, RoutedEventArgs e)
        {

            int valide = 0;

            if (tbxEmail.Text.Trim() == "")
            {


                erreuremail.Visibility = Visibility.Visible;
                valide += 1;

            }

            if (tbxpwd.Text.Trim() == "")
            {


                erreurnom.Visibility = Visibility.Visible;
                valide += 1;

            }

            if (valide == 0)
            {
               if( GestionBD.getInstance().connexionadmin(tbxEmail.Text, tbxpwd.Text) ==true)
                {

                    GestionBD.getInstance().NviAdmin.Visibility = Visibility.Visible;

                    this.Frame.Navigate(typeof(PageAdmin));
                }
                else
                {
                    erreuremailpass.Visibility = Visibility.Visible;
                }

            }
        }

        private void inscrire_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
