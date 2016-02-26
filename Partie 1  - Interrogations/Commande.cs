using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie_1____Interrogations
{
    public class Commande
    {
        public int NumCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public Double TotalTTCCommande { get; set; }
        public DateTime DateReglement { get; set; }
        public int EtatCommande { get; set; }
        public string BonDeCommande { get; set; }
        public Double TotalHT { get; set; }
        public Double Reduction { get; set; }
        public string Facture { get; set; }
        public DateTime DateFacture { get; set; }
        public int RefClient { get; set; }

    }
}
