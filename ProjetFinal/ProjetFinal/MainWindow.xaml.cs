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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private Frame GetMainFrame()
        {
            return mainFrame;
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Tag)
            {
                case "Admin":
                    mainFrame.Navigate(typeof(PageAdmin));
                    break;
                case "Chauffeur":
                    mainFrame.Navigate(typeof(PageChauffeur));
                    break;
                case "Client":
                    mainFrame.Navigate(typeof(PageClient));
                    break;
                case "Accueil":
                    mainFrame.Navigate(typeof(PageAccueil));
                    break;
                case "Creation":
                    mainFrame.Navigate(typeof(PageCreationCompte));
                    break;
                case "Con":
                    mainFrame.Navigate(typeof(pageConAdmin));
                    break ;
                default:
                    break;

            }
            try
            {
                tblHeader.Text = item.Content.ToString();
            }
            catch (Exception)
            {
                tblHeader.Text = "vide";

            };
        }

    }
    
}
