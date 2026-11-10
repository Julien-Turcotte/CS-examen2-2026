using Guignolee.Models;
using System.Collections.Generic;

namespace Guignolee.Data
{
    public interface IDonDataProvider
    {
        /// <summary>
        /// Retourne tous les dons.
        /// </summary>
        /// <returns></returns>
        List<Don> GetDons();

        /// <summary>
        /// Retourne le don correspondant à l'identifiant fourni.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Don? GetDonById(int id);

        /// <summary>
        /// Ajoute un don à la liste des dons.
        /// </summary>
        /// <param name="don"></param>
        void AjouterDon(Don don);

        /// <summary>
        /// Modifie un don existant dans la liste des dons. 
        /// Si le don n'existe pas, aucune action n'est effectuée.
        /// </summary>
        /// <param name="don"></param>
        void ModifierDon(Don don);

        /// <summary>
        /// Supprime le don ayant l'identifiant id de la liste des dons.
        /// </summary>
        /// <param name="id"></param>
        void SupprimerDon(int id);
    }
}
