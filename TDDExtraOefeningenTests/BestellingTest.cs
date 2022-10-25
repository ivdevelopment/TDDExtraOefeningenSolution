using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDExtraOefeningen;

namespace TDDExtraOefeningenTests
{
    [TestClass]
    public class BestellingTest
    {
        private Bestelling bestelling = null!;
        [TestInitialize]
        public void Initialize()
        {
            bestelling = new Bestelling();
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Add_HoeveelheidMoetGroterZijnDan0_Exception()
        {
            // arrange
            // act
            // assert
            bestelling.Add(new Artikel("Droogkast", 300m, 11m), 0); 
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Add_ArtikelMagNietNullZijn_Exception()
        {
            // arrange
            // act
            // assert
            bestelling.Add(null!, 1);
        }

        [TestMethod]
        public void TotalePrijs_MoetGelijkZijnAanAllePrijzenVanArtikels_IsTrue()
        {
            // arrange
            bestelling.Add(new Artikel("Droogkast", 300m, 11m), 3);
            bestelling.Add(new Artikel("Koelkast", 250m, 6m), 2);
            bestelling.Add(new Artikel("Vriezer", 400m, 11m), 2);
            bestelling.Add(new Artikel("Bed", 150m, 21m), 1);
            // act
            // assert
            Assert.AreEqual(2598.5m, bestelling.TotaalTeBetalen());

        }
    }
}
