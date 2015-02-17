using FileRepository.Handlers;
using FileRepository.IntegrationTests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.IntegrationTests.Handlers
{
    [TestClass]
    public class CollectionHandlerTests : IntegrationTestBase
    {
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
