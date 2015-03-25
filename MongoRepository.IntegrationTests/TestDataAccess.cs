using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.UnitTests.TestObjects;

namespace MongoRepository.IntegrationTests
{
    [TestClass]
    public class TestDataAccess
    {
        [TestMethod, TestCategory("IntegrationTests")]
        public void TestMethod1()
        {
            // Arrange
            var album = TestAlbum.CowboysFromHell();
            var dataAccess = new DataAccess();

            // Act
            dataAccess.Save(album);

            // Assert
			
        }
    }
}
