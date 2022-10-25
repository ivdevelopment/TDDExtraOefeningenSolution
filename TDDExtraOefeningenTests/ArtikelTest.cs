using TDDExtraOefeningen;

namespace TDDExtraOefeningenTests
{
    [TestClass]
    public class ArtikelTest
    {

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        // de naam mag niet null zijn
        public void Naam_IsGelijkAanNull_Exception()
        {
            new Artikel(null!, 200m, 11m);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        // naam moet ingevuld zijn
        public void Naam_IsNietIngevuld_Exception()
        {
            new Artikel("", 200m, 11m);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        // naam mag niet beginnen met een spatie
        public void Naam_BegintMetSpatie_Exception()
        {
            new Artikel(" koe lkast", 200m, 11m);
        }

        [TestMethod]
        // de prijs exclusief btw moet groter zijn dan nul
        public void PrijsExclusiefBtw_MoetEenPositiefGetalZijn_IsTrue()
        {
            // arrange
            var artikel = new Artikel("Douche", 150m, 11m);
            // act

            // assert
            Assert.IsTrue(artikel.PrijsExclusiefBTW > 0);
        }

        [TestMethod]
        // de btw percentage moet tussen 0.01 en 100 liggen
        public void BtwPercentage_MoetTussen001en100Zijn_IsTrue()
        {
            // arrange
            var artikel = new Artikel("Toilet", 120m, 8m);
            // act

            // assert
            Assert.IsTrue(artikel.BtwPercentage >= 0.01m && artikel.BtwPercentage <= 100m);
        }

        [TestMethod]
        // De prijs inclusief btw moet gelijk zijn aan de totale prijs
        public void PrijsInclusiefBtw_MoetGelijkZijnAan_DeTotalePrijs()
        {
            // arrange
            var artikel = new Artikel("Wasmachine", 550m, 11m);
            // act

            // assert
            Assert.AreEqual(610.5m, artikel.PrijsInclusiefBTW);
        }
    }
}