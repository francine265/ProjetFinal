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
    public sealed partial class Pageville : Page
    {
        public Pageville()
        {
            this.InitializeComponent();
        }
        private void ville_Click(object sender, RoutedEventArgs e)
        {
            int valide = 0;
            if (cmb.SelectedValue == null)
            {


                erreurcmb.Visibility = Visibility.Visible;
                valide += 1;

            }


            if (valide == 0)
            {

                GestionBD.getInstance().Ajoutville(cmb.SelectedItem.ToString());
                formville.Visibility = Visibility.Collapsed;
                tbl_texte.Visibility = Visibility.Visible;

            }

        }
    }
}
