using Common.Abstract;
using FileRepository.Handlers;
using FileRepository.IntegrationTests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRepository.IntegrationTests.Handlers
{
    [TestClass]
    public class MusicDirectoryTests : IntegrationTestBase
    {
        [TestMethod,TestCategory(Integration)]
        public void MusicDirectory_CanCreate()
        {
            // Arrange
            var dir = new MusicDirectory(_collectionDirectory);

            // Assert
            Assert.IsNotNull(dir);
        }

        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_GivenDirectoryWithNoMusicFiles_HasMusicFiles_IsFalse()
        {
            // Arrange
            var dir = GetDirectoryWithSubFoldersAndNoFiles(); 

            // Assert
            Assert.IsFalse(dir.ContainsMusicFiles());
        }
        
        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_GivenDirectoryWithMusicFiles_HasMusicFiles_IsTrue()
        {
            // Arrange
            var dir = GetDirectoryWithFiles(); 

            // Assert
            Assert.IsTrue(dir.ContainsMusicFiles());
        }

        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_GivenDirectoryWithNoAlbumArt_HasAlbumArtFiles_IsFalse()
        {
            // Arrange
            var dir = GetDirectoryWithSubFoldersAndNoFiles();

            // Assert
            Assert.IsFalse(dir.ContainsAlbumArt());
        }

        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_GivenDirectoryWithAlbumArt_HasAlbumArtFiles_IsTrue()
        {
            // Arrange
            var dir = GetDirectoryWithFiles(); 

            // Assert
            Assert.IsTrue(dir.ContainsAlbumArt());
        }
   
        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_WithAFolderThatHasSubFolders_HasSubFolders_IsTrue()
        {
            // Assert
            Assert.IsTrue(GetDirectoryWithSubFoldersAndNoFiles().HasSubFolders());
        }

        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_WithAFolderThatHasNoSubFolders_HasSubFolders_IsFalse()
        {
            // Assert
            Assert.IsFalse(GetDirectoryWithFiles().HasSubFolders());
        }

        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_GetSubFolders_ReturnsMusicDirectory()
        {
            // Arrange
            var dir = GetDirectoryWithSubFoldersAndNoFiles();

            // Act
            var subs = dir.GetSubFolders();

            // Assert
            Assert.AreEqual(1, subs.Count());
            Assert.IsInstanceOfType(subs[0], typeof(MusicDirectory));
        }

        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_GetSubFolders_WhereThereAreNone_ReturnsEmptyList()
        {
            // Arrange
            var dir = GetDirectoryWithFiles(); ;

            // Act
            var subs = dir.GetSubFolders();

            // Assert
            Assert.AreEqual(0, subs.Count());
        }

        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_GetMp3Files_ReturnsFiles()
        {
            // Arrange
            var dir = GetDirectoryWithFiles();

            // Act
            var files = dir.GetMusicFiles();

            // Assert
            Assert.IsInstanceOfType(files[0], typeof(FileInfo));
            Assert.AreEqual(10, files.Count);
           
        }
   
        [TestMethod, TestCategory(Integration)]
        public void MusicDirectory_AlbumArt_ReturnsFiles()
        {
            // Arrange
            var dir = GetDirectoryWithFiles();

            // Act
            var artFiles = dir.GetAlbumArtFiles();

            // Assert
            Assert.IsTrue(artFiles.Count > 0);

		}

        #region private helpers

        private MusicDirectory GetDirectoryWithFiles()
        {
            return new MusicDirectory(_testFolderHasFiles);
        }

        private MusicDirectory GetDirectoryWithSubFoldersAndNoFiles()
        {
            return new MusicDirectory(_testFolderNoFiles);
        }

        #endregion
    }
}
