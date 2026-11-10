using System;

namespace Guignolee.Models
{
    public class Don
    {
        public int Id { get; set; }
        public string Donateur { get; set; }
        public string Contenu { get; set; }

        public int Quantite { get; set; }

        public bool EstPerissable { get; set; } = false;
        public bool EstRemis { get; set; } = false;

        public DateTime DateReception { get; set; }

        public Don(string donateur = "", string contenu = "", int quantite = 0, bool estPerissable = false)
        {
            Donateur = donateur;
            Contenu = contenu;
            Quantite = quantite;
            EstPerissable = estPerissable;
            DateReception = DateTime.Now;
        }

    }
}
