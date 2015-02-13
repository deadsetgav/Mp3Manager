using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp3Handler;
using Common.Exceptions;
using System.IO;
using UnitTest.Mp3Handler.TestObjects;

namespace UnitTest.Mp3Handler
{
    [TestClass]
    public class FileReaderTests
    {
        #region Fixture Setup
        
        [ClassInitialize]
        public static void FixtureSetup(TestContext context)
        {
            if (File.Exists(_testCopyFile)) File.Delete(_testCopyFile);
            if (File.Exists(_testMoveFile)) File.Delete(_testMoveFile);
            if (File.Exists(_testDestFile)) File.Delete(_testDestFile);
        }

        #endregion

        private string _testFile = @"D:\testing\Ride\Going Blank Again\01 - Leave Them All Behind.mp3";
        private const string _testCopyFile = @"D:\testing\testCopy.mp3";
        private const string _testMoveFile = @"D:\testing\testMove.mp3";
        private const string _testDestFile = @"D:\testing\testDest.mp3";

        [TestMethod]
        public void GivenFilename_ReadMp3File()
        {
            // Arrange
            var fullFilePath =_testFile;
            var handler = new FileHandler();

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
            var handler = new FileHandler();

            // Act
            var mp3 = handler.Get(fullFilePath);

            // Assert
            Assert.Fail("we should have had an exception thrown by now");
        }

        [TestMethod]
        public void GivenFilename_CanOpenAndReadTagsOnFile()
        {
            // Arrage
            var fullFilePath = _testFile;
            var handler = new FileHandler();

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

        [TestMethod]
        public void WithMp3File_CheckCopyToIsCalled()
        {
            // Arrange
            var testWriter = new TestWriter();
            var handler = new FileHandler(testWriter);
            var mp3 = handler.Get(_testFile);

            // Act
            mp3.CopyTo(_testCopyFile);
            
            // Assert
            Assert.IsTrue(testWriter.CopyToCalled());
            Assert.AreEqual(_testCopyFile, testWriter.GetDestinationFileName());
        }

        [TestMethod]
        public void WithMp3File_CheckMoveToIsCalled()
        {
            // Arrange
            var testWriter = new TestWriter();
            var handler = new FileHandler(testWriter);
            var mp3 = handler.Get(_testFile);

            // Act
            mp3.MoveTo(_testCopyFile);

            // Assert
            Assert.IsTrue(testWriter.MoveToCalled());
            Assert.AreEqual(_testCopyFile, testWriter.GetDestinationFileName());
        }

        [TestMethod]
        public void WithMp3File_CopyToNewFile()
        {
            // Arrange
            var fullFilePath = _testFile;
            var handler = new FileHandler();
            var mp3 = handler.Get(_testFile);

            // Act
            mp3.CopyTo(_testCopyFile);

            // Assert
            Assert.IsTrue(File.Exists(_testCopyFile));
            Assert.IsTrue(File.Exists(_testFile));
        }
      
        [TestMethod]
        public void WithMp3File_MoveFile()
        {
            // Arrage
            File.Copy(_testFile, _testMoveFile);

            var handler = new FileHandler();
            var mp3 = handler.Get(_testMoveFile);

            // Act
            mp3.MoveTo(_testDestFile);

            // Assert
            Assert.IsTrue(File.Exists(_testDestFile));
            Assert.IsFalse(File.Exists(_testMoveFile));
        }

    }
}
