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
            GestionBD.getInstance().NviAdmin = nviAdmin;
            GestionBD.getInstance().NviChauffeur = nviChauffeur;
            GestionBD.getInstance().NviClient = nviClient;
            GestionBD.getInstance().NviDeConnexion = nviDeConnexion;
            GestionBD.getInstance().Nvinom=nvinom;
            GestionBD.getInstance().NviConnexion = nviConnexion;
            mainFrame.Navigate(typeof(PagePrincipale));
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
                    mainFrame.Navigate(typeof(PagePrincipale));
                    break;
                case "Creation":
                    mainFrame.Navigate(typeof(PageCreationCompte));
                    break;
                case "Connexion":
                    mainFrame.Navigate(typeof(OptionsConnexions));
                    break;
                case "DeConnexion":
                    GestionBD.getInstance().Deconnexion();
                    mainFrame.Navigate(typeof(PagePrincipale));
                    mainFrame.BackStack.Clear();
                    break;

                default:
                    break;

            }
        /*    try
            {
                tblHeader.Text = item.Content.ToString();
            }
            catch (Exception)
            {
                tblHeader.Text = "vide";

            };*/
        }

        private void NavigationView_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (mainFrame.CanGoBack)
            {
                mainFrame.GoBack();
            }


        }
    }
    
}
