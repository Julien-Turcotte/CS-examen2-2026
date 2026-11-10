using Guignolee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guignolee.Data
{
    public class DonDataProvider : IDonDataProvider
    {
        /// <summary>
        /// Liste statique des dons pour la persistance entre les pages.
        /// </summary>
        private static List<Don>? _dons;
        private static int _prochainId = 1;

        public void AjouterDon(Don don)
        {
            ArgumentNullException.ThrowIfNull(don);

            don.Id = _prochainId++;
            _dons?.Add(don);
        }

        public Don? GetDonById(int id)
        {
            return _dons?.FirstOrDefault(d => d.Id == id);
        }

        public List<Don> GetDons()
        {
            if (_dons == null)
            {
                _dons = new List<Don>();
                CreerDonsInitiaux();
            }

            return _dons;
        }

        public void ModifierDon(Don don)
        {
            Don? existant = GetDonById(don.Id);
            if (existant != null)
            {
                existant.Donateur = don.Donateur;
                existant.Contenu = don.Contenu;
                existant.Quantite = don.Quantite;
                existant.EstPerissable = don.EstPerissable;
                existant.EstRemis = don.EstRemis;
            }
        }

        public void SupprimerDon(int id)
        {
            Don? don = GetDonById(id);
            if (don is not null)
            {
                _dons?.Remove(don);
            }
        }

        private void CreerDonsInitiaux()
        {
            AjouterDon(new Don("Gyu Gnolet", "Pain et lait", 24, estPerissable: true)
            { DateReception = DateTime.Now.AddHours(-2) });

            AjouterDon(new Don("Club de robotique", "Conserves de soupe", 60)
            { DateReception = DateTime.Now.AddDays(-1) });

            AjouterDon(new Don("Soins infirmiers", "Pâtes et riz", 45)
            { DateReception = DateTime.Now.AddDays(-2), EstRemis = true });

            AjouterDon(new Don("Café contraste", "Fruits frais", 30, estPerissable: true)
            { DateReception = DateTime.Now.AddDays(-2).AddHours(-3) });

            AjouterDon(new Don("Département TI", "Céréales", 18)
            { DateReception = DateTime.Now.AddDays(-4) });

            AjouterDon(new Don("Association étudiante", "Couches et lingettes", 12)
            { DateReception = DateTime.Now.AddDays(-5), EstRemis = true });
        }
    }
}
