using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                lv.ItemsSource = GestionBD.getInstance().GetTrajetsdate(d1, d2);
            }

            //d2 = caleder2.Date.Value.DateTime;



        }

        private async void ecritureCSV_Click(object sender, RoutedEventArgs e)
        {

            var picker = new Windows.Storage.Pickers.FileSavePicker();

            /******************** POUR WINUI3 ***************************/

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(GestionBD.getInstance().Fenetre);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            /************************************************************/

            picker.SuggestedFileName = "Liste de Trajets";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            var liste = lv.ItemsSource as ObservableCollection<Trajets>;
            var l = liste.ToList();
            //var liste = Singleton.getInstance().GetTrajetsdate()

            //écrit dans le fichier chacune des lignes du tableau
            //une boucle sera faite sur la collection et prendra chacun des objets de celle-ci
            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, l.ConvertAll(x => x.exportationCSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);

        }
    }

}
