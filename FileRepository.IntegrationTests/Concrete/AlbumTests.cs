using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileRepository.IntegrationTests.TestObjects;
using FileRepository.Handlers;
using FileRepository.Concrete;
using Common.Abstract;
using FileRepository.UnitTests.TestObjects;

namespace FileRepository.IntegrationTests.Concrete
{
    [TestClass]
    public class AlbumTests : IntegrationTestBase
    {
        [TestMethod, TestCategory(Integration)]
        public void Album_CanCreate()
        {
            // Arrange
            var directory = new MusicDirectoryReader(@"D:\testing\Ride\Going Blank Again");
            var mp3Handler = new Mp3Handler(new TestWriter());
            
            // Act
            var album = new AlbumHandler(directory, mp3Handler);
            
            // Assert
            Assert.IsNotNull(album);  
        }

        [TestMethod, TestCategory(Integration)]
        public void Album_CanSeeTracks()
        {
            // Arrange
            var album = GoingBlankAgain().Populate();

            // Act
            var tracks = album.Tracks;
            var track = tracks.First();

            // Assert
            Assert.AreEqual(10, tracks.Count());
            Assert.IsInstanceOfType(track, typeof(IMp3Metadata));
            Assert.AreEqual("Going Blank Again",track.Album);

        }

   
    

        #region Private Helpers
        
        private AlbumHandler GoingBlankAgain()
        {
            var directory = new MusicDirectoryReader(@"D:\testing\Ride\Going Blank Again");
            var mp3Handler = new Mp3Handler(new TestWriter());

            // Act
            return new AlbumHandler(directory, mp3Handler);
        }

        #endregion

    }
}
