using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.UnitTests.TestObjects;
using MongoRepository.ModelMapping;

namespace MongoRepository.UnitTests.ModelMapping
{
    [TestClass]
    public class DataModelMapperTests
    {
        [TestMethod]
        public void DataMapper_MapMp3ToBson()
        {
            // Arrange
            var album = TestAlbum.AngelDust();
            var enumerator = album.Tracks.GetEnumerator();
            enumerator.MoveNext();
            var track = enumerator.Current;

            // Act
            var result = DataModelMapper.GetMp3AsBson(track).ToString();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(track.Title));

        }
    }
}
