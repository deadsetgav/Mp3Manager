using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicCollectionHandler;

namespace IntegrationTest.MusicCollectionHandler
{
    [TestClass]
    public class CollectionHandlerTests
    {
        private string _collectionDirectory = @"d:\testing\";


        [TestMethod, TestCategory("Integration")]
        public void GivenFilepath_CanReadCollection()
        {
            // Arrange
            var handler = new CollectionHandler();

            // Act
            var collection = handler.ReadCollection(_collectionDirectory);

            // Assert
            Assert.AreEqual(3, collection.Artists.Count);
        }
    }
}
