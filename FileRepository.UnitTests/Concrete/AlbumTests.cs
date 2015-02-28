using FileRepository.UnitTests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.UnitTests.Concrete
{
    [TestClass]
    public class AlbumTests
    {
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

    }
}
