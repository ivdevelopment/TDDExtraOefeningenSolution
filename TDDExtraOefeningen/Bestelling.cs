using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExtraOefeningen
{
    public class Bestelling
    {
        private List<Tuple<Artikel, int>> Artikels = new List<Tuple<Artikel, int>>();
        public void Add(Artikel artikel, int hoeveelheid)
        {
            if (artikel == null)
                throw new ArgumentException("De naam van de artikel is geen geldige artikel!");
            if (hoeveelheid <= decimal.Zero)
                throw new ArgumentException("Het bedrag moet positief zijn");
            Artikels.Add(new Tuple<Artikel, int>(artikel, hoeveelheid));
        }

        public decimal TotaalTeBetalen()
        {
            var totaal = 0m;
            foreach (var artikel in Artikels)
            {
                totaal += artikel.Item1.PrijsInclusiefBTW * artikel.Item2;
            }
            return totaal;
        }

        public decimal TotaleHoeveelheid()
        {
            var totaal = 0;
            foreach (var artikel in Artikels)
            {
                totaal += artikel.Item2;
            }
            return totaal;
        }
    }
}
