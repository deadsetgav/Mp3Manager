using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Common.Abstract;
using Common.UnitTests.TestObjects;

namespace Common.UnitTests.Models
{
    [TestClass]
    public class MusicCollectionTests
    {
        [TestMethod]
        public void MusicCollection_CanCreate()
        {            
            // Act
            IMusicCollection collection = new MusicCollection();

            // Assert
            Assert.AreEqual(0, collection.ArtistCount);
        }

        [TestMethod]
        public void MusicCollection_CanAddArtist()
        {
            // Arrange
            var artist = new Artist("Slayer");
            IMusicCollection collection = new MusicCollection();

            // Act
            collection = collection.Add(artist);

            // Assert
            Assert.AreEqual(1, collection.ArtistCount);
        }

        [TestMethod]
        public void MusicCollection_CanAddTwoArtists()
        {
            // Arrange
            var artist1 = new Artist("Megadeth");
            var artist2 = new Artist("Testament");
            IMusicCollection collection = new MusicCollection();

            // Act
            collection = collection
                            .Add(artist1)
                            .Add(artist2);
            
            // Assert
            Assert.AreEqual(2, collection.ArtistCount);
        }

        [TestMethod]
        public void MusicCollection_CannotAddSameArtistTwice()
        {
            // Arrange
            var artist = new Artist("Anthrax");
            IMusicCollection collection = new MusicCollection();

            // Act
            collection = collection
                            .Add(artist)
                            .Add(artist);
            
            // Assert
            Assert.AreEqual(1, collection.ArtistCount);
        }

        [TestMethod]
        public void MusicCollection_CheckObjectIsImmutable()
        {
            // Arrange
            var artist1 = new Artist("Exodus");
            var artist2 = new Artist("Metallica");
            IMusicCollection collection = new MusicCollection();

            // Act
            collection.Add(artist1);
            collection.Add(artist2);

            // Assert
            Assert.AreEqual(0, collection.ArtistCount, "initial collection object should not change");
        }

        [TestMethod]
        public void MusicCollection_CollectionContains_ArtistName_IsTrue()
        {
            // Arrange
            IMusicCollection collection = new MusicCollection()
                .Add(new Artist("Megadeth"));

            // Assert
            Assert.IsTrue(collection.ContainsArtist("Megadeth"));
            Assert.IsTrue(collection.ContainsArtist(new Artist("Megadeth")));
        }

        [TestMethod]
        public void MusicCollection_CollectionContains_UnknownArtistName_IsFalse()
        {
            // Arrange
            IMusicCollection collection = new MusicCollection()
                .Add(new Artist("Megadeth"));

            // Assert
            Assert.IsFalse(collection.ContainsArtist("Exodus"));
            Assert.IsFalse(collection.ContainsArtist(new Artist("Anvil")));
        }

        [TestMethod]
        public void MusicCollection_CanAddAlbum_WhenArtistDoesntExist()
        {
            // Arrange
            IMusicCollection collection = new MusicCollection();
            var album = new TestAlbum
            {
                ArtistName = "Metallica",
                Title = "Ride The Lightning"
            };

            // Act
            collection = collection.Add(album);

            // Assert
            Assert.AreEqual(1, collection.ArtistCount);
        }

        [TestMethod]
        public void MusicCollection_CanAddAlbum_WhenArtistAlreadyExists()
        {
            // Arrange
            IMusicCollection collection = new MusicCollection()
                                            .Add(new Artist("Anthrax"));
            var album = new TestAlbum
            {
                ArtistName = "Anthrax",
                Title = "Among The Living"
            };

            // Act
            collection = collection.Add(album);

            // Assert
            Assert.AreEqual(1, collection.ArtistCount);           
        }
    }
}
