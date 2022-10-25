using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExtraOefeningen
{
    public class Artikel
    {
        public Artikel(string naam, decimal prijsExclusiefBTW, decimal btwPercentage)
        {
            Naam = naam;
            PrijsExclusiefBTW = prijsExclusiefBTW;
            BtwPercentage = btwPercentage;
        }
        private string naam;
        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("Het artikel moet geldig zijn.");
                if (value == "")
                    throw new ArgumentException("Het artikel moet ingevuld zijn.");
                if (value.StartsWith(" "))
                    throw new ArgumentException("Het artikel mag niet met een spatie beginnen.");
                naam = value;
            }
        }
        private decimal prijsExclusiefBTW;
        public decimal PrijsExclusiefBTW
        {
            get
            {
                return prijsExclusiefBTW;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Prijs mag niet kleiner zijn dan 0");
                prijsExclusiefBTW = value;
            }
        }
        private decimal btwPercentage;
        public decimal BtwPercentage
        {
            get
            {
                return btwPercentage;
            }
            set
            {
                if (value < 0.01m || value > 100m)
                    throw new ArgumentException("BTW percentage moet tussen 0.01 en 100 liggen");
                btwPercentage = value;
            }
        }
        public decimal PrijsInclusiefBTW
        {
            get
            {
                return (PrijsExclusiefBTW * (BtwPercentage / 100)) + PrijsExclusiefBTW;
            }
        }
    }
}
