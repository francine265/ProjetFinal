﻿using Microsoft.UI.Xaml;
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
    public sealed partial class creationClient : Page
    {
        public creationClient()
        {
            this.InitializeComponent();
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
    }
}
