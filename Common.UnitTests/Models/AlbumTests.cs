using Common.Abstract;
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
    public class AlbumTests
    {
        [TestMethod]
        public void Album_NoAvailableAlbumTitle_SetToUnknown()
        {
            // Arrange
            var trackList = new List<IMp3Metadata>();
            trackList.Add(new TestTrack
            {
                Track = "01",
                Title = "Heartwork",
                Artist = "Carcass",
                Year = "1993"
            });

            // Act
            var album = new Album(trackList);

            // Assert
            Assert.AreEqual("Unknown Album", album.Title);
        }

        [TestMethod]
        public void Album_AllTracksHaveSameAlbum_TitlePopulatesCorrectly()
        {
            // Arrange
            var album = TestAlbum.CowboysFromHell();

            // Act
            var albumTitle = album.Title;

            // Assert
            Assert.AreEqual("Cowboys From Hell", albumTitle);
        }

        [TestMethod]
        public void Album_SomeTracksHaveSlightlyDifferentAlbum_TitlePopulatesCorrectly()
        {
            // Arrange
            var album = TestAlbum.RoadsToJudah();

            // Assert
            Assert.AreEqual("Roads To Judah", album.Title);
        }

        [TestMethod]
        public void Album_ArtistNameSameAcrossAllTracks_ArtistPopulatesCorrectly()
        {
            // Arrange
            var album = TestAlbum.CowboysFromHell();

            // Assert 
            Assert.AreEqual("Pantera", album.ArtistName);
        }

        [TestMethod]
        public void Album_ArtistNameSlightlyDiffers_ArtistPopulatesCorrectly()
        {
            // Arrange
            var album = TestAlbum.AngelDust();

            // Assert
            Assert.AreEqual("Faith No More", album.ArtistName);
        }

        [TestMethod]
        public void Album_Year_IsPopulated()
        {
            // Arrange
            var album = TestAlbum.AngelDust();

            // Assert
            Assert.AreEqual("1992", album.Year);
        }

        [TestMethod]
        public void Album_MostCommonYear_IsUsed()
        {
            // Arrange
            var album = TestAlbum.Sap();

            // Assert
            Assert.AreEqual("1994", album.Year);
        }

        [TestMethod]
        public void Album_NoYearSet()
        {
            // Arrage
            var album = TestAlbum.Babyteeth();

            // Assert
            Assert.AreEqual(string.Empty, album.Year);
        }
    
        [TestMethod]
        public void Album_Save_TracksSaved()
        {
            // Arrage
            var album = TestAlbum.Babyteeth();

            // Act
            album.Save();

            // Assert
            foreach (var track in album.Tracks)
            {
                Assert.IsTrue((track as TestTrack).Saved);
            }
        }
    }
}
