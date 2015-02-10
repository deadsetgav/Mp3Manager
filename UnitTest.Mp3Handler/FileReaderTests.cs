using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp3Handler;

namespace UnitTest.Mp3Handler
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void GivenFilename_ReadMp3File()
        {
            // Arrange
            var fullFilePath = @"D:\testing\Ride\Going Blank Again\01 - Leave Them All Behind.mp3";
            var handler = new Handler();

            // Act
            var mp3 = handler.Get(fullFilePath);

            // Assert
            Assert.AreEqual(fullFilePath, mp3.FullFilePath);
            Assert.AreEqual("Ride", mp3.AlbumArtist);

        }
    }
}
