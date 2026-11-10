using Guignolee.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Guignolee.ViewModels
{
    public class DonViewModel : ValidableViewModel
    {
        private readonly Don _don;

        public DonViewModel(Don don)
        {
            _don = don;
            _errors.Add(nameof(Donateur), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(Contenu), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(Quantite), new ObservableCollection<ValidationResult>());
        }

        public int Id => _don.Id;

        [Required (ErrorMessage = "Le donateur est obligatoire.")]
        [Length(2, 50, ErrorMessage = "De 2 à 50 charactères.")]
        [RegularExpression ("^[\\da-zA-Z ]+$", ErrorMessage = "Peut contenir seulement des lettres, chiffres et des espaces.")]
        public string Donateur
        {
            get { return _don.Donateur; }
            set
            {
                if (_don.Donateur != value && Validate(value))
                {
                    _don.Donateur = value;
                }
            }
        }

        [Required(ErrorMessage = "Le contenu est obligatoire.")]
        [Length (2, 50, ErrorMessage = "De 2 à 50 charactères.")]
        [RegularExpression ("^[\\da-zA-Z ]+$", ErrorMessage = "Peut contenir seulement des lettres, chiffres et des espaces.")]
        public string Contenu
        {
            get { return _don.Contenu; }
            set
            {
                if (_don.Contenu != value && Validate(value))
                {
                    _don.Contenu = value;
                }
            }
        }

        [Required(ErrorMessage = "La quantité est obligatoire.")]
        [Range ( 1, 100, ErrorMessage = "1 à 100.")]
        [RegularExpression ("^\\d+$", ErrorMessage = "La quantité doit être un nombre")]
        public int Quantite
        {
            get { return _don.Quantite; }
            set
            {
                if (Quantite != value && Validate(value))
                {
                    _don.Quantite = value;

                }
            }
        }

        public bool EstPerissable
        {
            get { return _don.EstPerissable; }
            set
            {
                if (_don.EstPerissable != value)
                {
                    _don.EstPerissable = value;
                }
            }
        }

        public bool EstRemis
        {
            get { return _don.EstRemis; }
            set
            {
                if (_don.EstRemis != value)
                {
                    _don.EstRemis = value;
                }
            }
        }

        public DateTime DateReception => _don.DateReception;

        public string Details
        {
            get
            {
                return $"{_don.Quantite} article(s) - {_don.Donateur} - reçu le {_don.DateReception:dd-MM-yyyy}";
            }
        }
    }
}
