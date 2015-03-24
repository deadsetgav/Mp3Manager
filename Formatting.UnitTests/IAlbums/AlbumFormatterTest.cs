using Formatting.IAlbums;
using Formatting.UnitTests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.UnitTests.IAlbums
{
    [TestClass]
    public class AlbumFormatterTest
    {
        [TestMethod]
        public void AlbumFormat_TestFormatReadyForCollection_FormatsAlbum()
        {
            // Arrange
            var album = TestAlbum.AngelDust();

            // Act
            album = Format.ReadyForCollection(album);

            // Assert
            foreach (var mp3 in album.Tracks)
            {
                Assert.AreEqual("Faith No More", mp3.Artist);
                Assert.AreEqual("Faith No More", mp3.AlbumArtist);
                Assert.AreEqual("Angel Dust", mp3.Album);
                Assert.AreEqual("1992", mp3.Year);
                Assert.IsFalse(mp3.Track.StartsWith("0"));
            }
			
        }
    }
}
