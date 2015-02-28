using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UnitTests.Models
{
    [TestClass]
    public class ArtistTests
    {
        [TestMethod]
        public void Artist_CanCreate()
        {
            // Arrage
            var testName = "Faith No More";

            // Act
            var artist = new Artist(testName);

            // Assert
            Assert.AreEqual(testName, artist.Name);
        }

        [TestMethod]
        public void Artist_TwoSameArtists_AreEqual()
        {
            // Arrange
            var artist1 = new Artist("Soundgarden");
            var artist2 = new Artist("soundgarden");

            // Assert
            Assert.AreEqual(artist1, artist2);
        }
        
        [TestMethod]
        public void Artist_TwoDifferentArtists_AreEqual()
        {
            // Arrange
            var artist1 = new Artist("Soundgarden");
            var artist2 = new Artist("Alice In Chains");

            // Assert
            Assert.AreNotEqual(artist1, artist2);
        }

    }
}
