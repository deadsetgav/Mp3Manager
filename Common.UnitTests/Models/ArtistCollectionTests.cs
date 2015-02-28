using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Common.Abstract;

namespace Common.UnitTests.Models
{
    [TestClass]
    public class ArtistCollectionTests
    {
        [TestMethod]
        public void ArtistCollection_CanCreate()
        {            
            // Act
            IArtistCollection collection = new ArtistCollection();

            // Assert
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void ArtistCollection_CanAddArtist()
        {
            // Arrange
            var artist = new Artist("Slayer");
            IArtistCollection collection = new ArtistCollection();

            // Act
            collection = collection.Add(artist);

            // Assert
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void ArtistCollection_CanAddTwoArtists()
        {
            // Arrange
            var artist1 = new Artist("Megadeth");
            var artist2 = new Artist("Testament");
            IArtistCollection collection = new ArtistCollection();

            // Act
            collection = collection
                            .Add(artist1)
                            .Add(artist2);
            
            // Assert
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void ArtistCollection_CannotAddSameArtistTwice()
        {
            // Arrange
            var artist = new Artist("Anthrax");
            IArtistCollection collection = new ArtistCollection();

            // Act
            collection = collection
                            .Add(artist)
                            .Add(artist);
            
            // Assert
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void ArtistCollection_CheckObjectIsImmutable()
        {
            // Arrange
            var artist1 = new Artist("Exodus");
            var artist2 = new Artist("Metallica");
            IArtistCollection collection = new ArtistCollection();

            // Act
            collection.Add(artist1);
            collection.Add(artist2);

            // Assert
            Assert.AreEqual(0, collection.Count, "initial collection object should not change");
        }

    }
}
