using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.UnitTests.Models
{
    [TestClass]
    public class ArtistCollectionTests
    {
        [TestMethod]
        public void WithArtistCollection_CanCreate()
        {            
            // Act
            var collection = new ArtistCollection();

            // Assert
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void WithArtistCollection_CanAddArtist()
        {
            // Arrange
            var artist = new Artist("Slayer");
            var collection = new ArtistCollection();

            // Act
            collection.Add(artist);

            // Assert
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void WithArtistCollection_CanAddTwoArtists()
        {
            // Arrange
            var artist1 = new Artist("Megadeth");
            var artist2 = new Artist("Testament");
            var collection = new ArtistCollection();

            // Act
            collection.Add(artist1);
            collection.Add(artist2);

            // Assert
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void WithArtistCollection_CannotAddSameArtistTwice()
        {
            // Arrange
            var artist = new Artist("Anthrax");
            var collection = new ArtistCollection();

            // Act
            collection.Add(artist);
            collection.Add(artist);

            // Assert
            Assert.AreEqual(1, collection.Count);
        }

    }
}
