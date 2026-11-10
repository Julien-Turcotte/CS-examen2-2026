using Guignolee.Data;
using Guignolee.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Guignolee.ViewModels.Pages
{
    public class RegistreViewModel : BaseViewModel
    {
        private readonly IDonDataProvider _donDataProvider;

        public ObservableCollection<DonViewModel> Dons { get; } = new ObservableCollection<DonViewModel>();

        private DonViewModel _nouveauDon;
        public DonViewModel NouveauDon
        {
            get { return _nouveauDon; }
            set
            {
                if (_nouveauDon != value)
                {
                    _nouveauDon = value;
                    RaisePropertyChanged();
                }
            }
        }

        private DonViewModel? _donSelectionne;
        public DonViewModel? DonSelectionne
        {
            get { return _donSelectionne; }
            set
            {
                if (_donSelectionne != value)
                {
                    _donSelectionne = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Propriété calculée qui retourne un résumé de l'état des dons à remettre.
        /// Elle est utilisée pour être afficher le nombre total de dons, le nombre de 
        /// dons périssables et le nombre de dons déjà remis.
        /// </summary>
        public string EtatDons
        {
            get
            {
                int nbRemis = _donDataProvider.GetDons().Count(d => d.EstRemis);
                return $"{Dons.Count} don(s) à remettre, dont {Dons.Count(d => d.EstPerissable)} périssable(s) - {nbRemis} déjà remis";
            }
        }

        public RegistreViewModel(IDonDataProvider donDataProvider)
        {
            _donDataProvider = donDataProvider;
            _nouveauDon = new DonViewModel(new Don());
        }

        /// <summary>
        /// Charge (ou recharge) la liste des dons à remettre à partir du fournisseur de données.
        /// Seuls les dons qui ne sont pas encore remis sont affichés. Ils sont placés dans cet ordre :
        /// - les dons périssables, du plus ancien au plus récent ;
        /// - les autres dons, du plus ancien au plus récent.
        /// </summary>
        public void ChargerDonnees()
        {
            // TODO: À compléter selon la documentation de la méthode.

            DonSelectionne = null;
        }

        /// <summary>
        /// Permet d'ajouter le nouveau don du formulaire à la liste des dons à remettre. 
        /// Le don est ajouté au fournisseur de données et la liste des dons est rechargée.
        /// </summary>
        public void AjouterDon()
        {
            _donDataProvider.AjouterDon(new Don(NouveauDon.Donateur, NouveauDon.Contenu, NouveauDon.Quantite, NouveauDon.EstPerissable));
            ChargerDonnees();
            NouveauDon = new DonViewModel(new Don());
        }
    }
}
