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
    public sealed partial class ModificationDonPage : Page
    {
        public ModifierDonViewModel ViewModel;

        public ModificationDonPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is DonViewModel don)
            { 
                ViewModel = new ModifierDonViewModel(don);
            }
        }

        private async void EnregistrerClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.DonEdit.EstValide)
            {
                ContentDialog dialogueSuppression = new ContentDialog
                {
                    Title = "Modification",
                    Content =  "Voulez-vous confirmer la modification de ce don?",
                    PrimaryButtonText = "Enregistrer",
                    CloseButtonText = "Annuler"
                };

                dialogueSuppression.XamlRoot = this.XamlRoot;

                ContentDialogResult result = await dialogueSuppression.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    Frame.Navigate(typeof(RegistrePage));
                }
            }
        }
    }
}
