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
    public sealed partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            this.InitializeComponent();
        }

        private void btnAjoutVille_Click(object sender, RoutedEventArgs e)
        {
            //ville vi = cmb.SelectedItem as ville;

            Singleton.getInstance().Ajouterville(cmb.SelectedItem.ToString() ,email.Text);
        }



        private void btn_Click(object sender, RoutedEventArgs e)
        {
            lv.ItemsSource = Singleton.getInstance().GetTrajets();
        }
    }
}
