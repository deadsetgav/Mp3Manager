using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using FileRepository.Handlers;
using FileRepository.IntegrationTests.TestObjects;
using Common.Exceptions;

namespace FileRepository.IntegrationTests.Handlers
{
    [TestClass]
    public class Mp3HandlerTests : IntegrationTestBase
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

        #endregion

        [TestMethod, TestCategory("Integration")]
        public void GivenFilename_ReadMp3File()
        {
            // Arrange
            var fullFilePath = _testFile;
            var handler = new Mp3Handler();

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
            var handler = new Mp3Handler();

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
            var handler = new Mp3Handler();

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
            var handler = new Mp3Handler(testWriter);
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
            var handler = new Mp3Handler(testWriter);
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
            var handler = new Mp3Handler();
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

            var handler = new Mp3Handler();
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

            var handler = new Mp3Handler();
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
