using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.UnitTests.TestObjects;

namespace MongoRepository.IntegrationTests
{
    [TestClass]
    public class DataAccessTests
    {
        DataAccess _db;

        [TestInitialize]
        public void Setup()
        {
            _db = new DataAccess("IntegrationTests");
        }

        [TestMethod, TestCategory("IntegrationTests")]
        public void MongoRepo_CanSaveAlbum()
        {
            // Arrange
            var album = TestAlbum.CowboysFromHell();
           
            // Act
            _db.Save(album);

            // Assert
            Assert.IsTrue(_db.Exists(album.ArtistName, album.Title));
        }
    }
}
