using Common.Abstract;
using Common.Exceptions;
using Common.Models;
using Common.UnitTests.TestObjects;
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
        [ExpectedException(typeof(ArtistNameNullException))]
        public void Artist_ArtistName_CantBeEmpty()
        {
            // Act
            var artist = new Artist("");            

            // Assert
            Assert.Fail("should have thrown an exception");	
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

        [TestMethod]
        public void Artist_CanAddAlbum()
        {
            // Arrange
            IArtist artist = new Artist("Mudhoney");
            var album = new TestAlbum
            {
                ArtistName = "Mudhoney",
                Title = "Touch Me I'm Sick"
            };

            // Act
            artist = artist.Add(album);

            // Assert
            Assert.AreEqual(1, artist.Albums.Count());
        }

        [TestMethod]
        public void Artist_CanAddTwoAlbums()
        {
            // Arrange
            var album1 = new TestAlbum
            {
                ArtistName = "Screaming Trees",
                Title = "Sweet Oblivion"
            };
            var album2 = new TestAlbum
            {
                ArtistName = "Screaming Trees",
                Title = "Dust"
            };

            // Act
            IArtist artist = new Artist("Screaming Trees")
                .Add(album1).Add(album2);

            // Assert
            Assert.AreEqual(2, artist.Albums.Count());
        }
    }
}
