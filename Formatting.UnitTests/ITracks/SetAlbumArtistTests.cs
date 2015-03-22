using Formatting.ITracks;
using Formatting.UnitTests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting.UnitTests.ITracks
{
    [TestClass]
    public class SetAlbumArtistTests
    {
        [TestMethod]
        public void TrackFormat_SetAlbumArtist_OnTrackWithNullAlbumArtist()
        {
            // Arrange
            var troublegum = new TestAlbum("Troublegum", "Therapy?");
            var format = new SetAlbumArtist(troublegum);

            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01"
            };

            // Act
            format.Format(mp3);

            // Assert
            Assert.AreEqual("Therapy?", mp3.AlbumArtist);
        }

        [TestMethod]
        public void TrackFormat_SetAlbumArtist_OverwritesIncorrectValue()
        {
            // Arrange
            var troublegum = new TestAlbum("Troublegum", "Therapy?");
            var format = new SetAlbumArtist(troublegum);

            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01",
                AlbumArtist = "Terrorvision"
            };

            // Act
            format.Format(mp3);

            // Assert
            Assert.AreEqual("Therapy?", mp3.AlbumArtist);
        }
    }
}
