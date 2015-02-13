using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicCollectionHandler;
using Common.Exceptions;
using System.IO;
using IntegrationTest.MusicCollectionHandler.TestObjects;

namespace IntegrationTest.MusicCollectionHandler
{
    [TestClass]
    public class Mp3FileTests
    {
        #region Fixture Setup & Teardown
        
        [ClassInitialize]
        public static void FixtureSetup(TestContext context)
        {
            CleanUp(); 
        }

        [ClassCleanup]
        public static void FixtureTeardown()
        {
            CleanUp();
        }

        private static void CleanUp()
        {
            if (File.Exists(_testCopyFile)) File.Delete(_testCopyFile);
            if (File.Exists(_testMoveFile)) File.Delete(_testMoveFile);
            if (File.Exists(_testDestFile)) File.Delete(_testDestFile);
            if (File.Exists(_testSaveFile)) File.Delete(_testSaveFile);
        }  
        #endregion

        private string _testFile = @"D:\testing\Ride\Going Blank Again\01 - Leave Them All Behind.mp3";
        private const string _testCopyFile = @"D:\testing\testCopy.mp3";
        private const string _testMoveFile = @"D:\testing\testMove.mp3";
        private const string _testDestFile = @"D:\testing\testDest.mp3";
        private const string _testSaveFile = @"D:\testing\testSave.mp3";

        [TestMethod, TestCategory("Integration")]
        public void GivenFilename_ReadMp3File()
        {
            // Arrange
            var fullFilePath =_testFile;
            var handler = new CollectionHandler();

            // Act
            var mp3 = handler.Get(fullFilePath);

            // Assert
            Assert.AreEqual(fullFilePath, mp3.FullFilePath);

        }

        [TestMethod, TestCategory("Integration")]
        [ExpectedException(typeof(ErrorRetrievingMp3Exception))]
        public void GivenBadFilename_GetException()
        {
            // Arrage
            var fullFilePath = @"D:\testing\Ride\Going Blank Again\00 -Doesn't Exist.mp3";
            var handler = new CollectionHandler();

            // Act
            var mp3 = handler.Get(fullFilePath);

            // Assert
            Assert.Fail("we should have had an exception thrown by now");
        }

        [TestMethod, TestCategory("Integration")]
        public void GivenFilename_CanOpenAndReadTagsOnFile()
        {
            // Arrage
            var fullFilePath = _testFile;
            var handler = new CollectionHandler();

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

        [TestMethod, TestCategory("Integration")]
        public void WithMp3File_CheckCopyToIsCalled()
        {
            // Arrange
            var testWriter = new TestWriter();
            var handler = new CollectionHandler(testWriter);
            var mp3 = handler.Get(_testFile);

            // Act
            mp3.CopyTo(_testCopyFile);
            
            // Assert
            Assert.IsTrue(testWriter.CopyToCalled());
            Assert.AreEqual(_testCopyFile, testWriter.GetDestinationFileName());
        }

        [TestMethod, TestCategory("Integration")]
        public void WithMp3File_CheckMoveToIsCalled()
        {
            // Arrange
            var testWriter = new TestWriter();
            var handler = new CollectionHandler(testWriter);
            var mp3 = handler.Get(_testFile);

            // Act
            mp3.MoveTo(_testCopyFile);

            // Assert
            Assert.IsTrue(testWriter.MoveToCalled());
            Assert.AreEqual(_testCopyFile, testWriter.GetDestinationFileName());
        }

        [TestMethod, TestCategory("Integration")]
        public void WithMp3File_CopyToNewFile()
        {
            // Arrange
            var fullFilePath = _testFile;
            var handler = new CollectionHandler();
            var mp3 = handler.Get(_testFile);

            // Act
            mp3.CopyTo(_testCopyFile);

            // Assert
            Assert.IsTrue(File.Exists(_testCopyFile));
            Assert.IsTrue(File.Exists(_testFile));
        }

        [TestMethod, TestCategory("Integration")]
        public void WithMp3File_MoveFile()
        {
            // Arrage
            File.Copy(_testFile, _testMoveFile);

            var handler = new CollectionHandler();
            var mp3 = handler.Get(_testMoveFile);

            // Act
            mp3.MoveTo(_testDestFile);

            // Assert
            Assert.IsTrue(File.Exists(_testDestFile));
            Assert.IsFalse(File.Exists(_testMoveFile));
        }

        [TestMethod, TestCategory("Integration")]
        public void WithMp3File_ChangeAndSave()
        {
            // Arrage
            File.Copy(_testFile, _testSaveFile);

            var handler = new CollectionHandler();
            var mp3 = handler.Get(_testSaveFile);
            
            // Act
            mp3.AlbumArtist = "Whirr";
            mp3.Save();

            // Assert
            var checkMp3 = handler.Get(_testSaveFile);
            Assert.AreNotEqual("Ride", mp3.AlbumArtist);
            Assert.AreEqual("Whirr", mp3.AlbumArtist);
            Assert.AreEqual("Going Blank Again", mp3.Album);
        }

         
    }
}
