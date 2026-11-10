using Guignolee.Data;
using Guignolee.ViewModels;
using Guignolee.ViewModels.Pages;
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

namespace Guignolee.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrePage : Page
    {
        public RegistreViewModel ViewModel { get; }
        public RegistrePage()
        {
            ViewModel = new RegistreViewModel(new DonDataProvider());
            InitializeComponent();
            Loaded += MaisonPage_Loaded;
        }

        private void MaisonPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ChargerDonnees();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            // TODO: À compléter
        }

        private void btnMarquerRemis_Click(object sender, RoutedEventArgs e)
        {
            // TODO: À compléter
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AjouterDon();
        }
    }
}
