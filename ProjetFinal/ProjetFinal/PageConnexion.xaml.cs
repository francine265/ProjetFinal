// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public sealed partial class PageConnexion : Page
    {

      //  bool ok = false;
        bool validite = true;

      //  public bool Ok { get => ok; }


        public PageConnexion()
        {
            this.InitializeComponent();
        }

        private void btConnexion_Click(object sender, RoutedEventArgs e)
        {

            
            
                if (tbxMail.Text == null || tbxMail.Text == "")
                {
                    ErrMail.Visibility = Visibility.Visible;
                    validite = false;
                }
                else
                {
                    ErrMail.Visibility = Visibility.Collapsed;
                }


                if (tbxMotDePasse.Password == null || tbxMotDePasse.Password == "")
                {
                    ErrMotDePasse.Visibility = Visibility.Visible;
                    validite = false;
                }
                else
                {
                    ErrMotDePasse.Visibility = Visibility.Collapsed;
                }


                if (validite==true)
                {
              //  Chauffeur c = new Chauffeur()
              //  {
               //     Email = tbxMail.Text,
                //    MotDePasse = tbxMotDePasse.Password
                //    };


                 Singleton.getInstance().connexionChauff(tbxMail.Text, tbxMotDePasse.Password);

                if(Singleton.getInstance().connexionChauff(tbxMail.Text, tbxMotDePasse.Password))
                {

                }
                }


            }
        }
    }

