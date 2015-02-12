using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp3Handler;
using Common.Exceptions;

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

        }
 
        [TestMethod]
        [ExpectedException(typeof(ErrorRetrievingMp3Exception))]
        public void GivenBadFilename_GetException()
        {
            // Arrage
            var fullFilePath = @"D:\testing\Ride\Going Blank Again\00 -Doesn't Exist.mp3";
            var handler = new Handler();

            // Act
            var mp3 = handler.Get(fullFilePath);

            // Assert
            Assert.Fail("we should have had an exception thrown by now");
        }

        [TestMethod]
        public void GivenFilename_CanOpenAndReadTagsOnFile()
        {
            // Arrage
            var fullFilePath = @"D:\testing\Ride\Going Blank Again\01 - Leave Them All Behind.mp3";
            var handler = new Handler();

            // Act
            var mp3 = handler.Get(fullFilePath);

            // Assert
            Assert.AreEqual("Ride", mp3.Artist);
            Assert.AreEqual("Ride", mp3.AlbumArtist);
            Assert.AreEqual("Leave Them All Behind", mp3.Title);
            Assert.AreEqual("1", mp3.Track);
            Assert.AreEqual("Going Blank Again", mp3.Album);
            Assert.AreEqual("1992", mp3.Year);
            Assert.AreEqual(320, mp3.BitRate);
        }

       
      
    }
}
