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
    public sealed partial class OptionsConnexions : Page
    {
        public OptionsConnexions()
        {
            this.InitializeComponent();
        }

        private void Connadmin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pageConAdmin));

        }

        private void ConnChauffeur_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PageConChauffeur));
        }

        private void connClient_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Connexion));

        }
    }
}
