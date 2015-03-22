using Common.Abstract;
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
    public class IFormatTracksTests
    {

        [TestMethod]
        public void TrackFormat_UseTrimTitleAndPrecedingZeros()
        {
            // Arrange
            var format = new RemovePrecedingZerosFromTrackNumber()
                .Add(new RemoveTrackNumberFromSongTitle());
                

            var mp3 = GetTestTrack();

            // Act
            format.Format(mp3);

            // Assert
            Assert.AreEqual("1", mp3.Track);
            Assert.AreEqual("Knives", mp3.Title);
        }

        [TestMethod]
        public void TrackFormat_IncludeSetAlbumArtist()
        {
            // Arrange
            var album = GetTestAlbum();
            var format = new RemovePrecedingZerosFromTrackNumber()
                .Add(new RemoveTrackNumberFromSongTitle())
                .Add(new SetAlbumArtist(album));
               

            var mp3 = GetTestTrack();

            // Act
            format.Format(mp3);

            // Assert
            Assert.AreEqual("1", mp3.Track);
            Assert.AreEqual("Knives", mp3.Title);
            Assert.AreEqual("Therapy?", mp3.AlbumArtist);
        }

        [TestMethod]
        public void TrackFormat_CheckOrder()
        {
            // Arrange
            var album = GetTestAlbum();
            var format = new TestFormatOne()
                .Add(new TestFormatTwo())
                .Add(new TestFormatThree());

            var mp3 = GetTestTrack();

            // Act
            format.Format(mp3);

            // Assert
            Assert.AreEqual("01 - Knives - Format-1 - Format-2 - Format-3", mp3.Title);
           
        }

        private IMp3Metadata GetTestTrack()
        {
            return new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01"
            };
        }

        private IAlbum GetTestAlbum()
        {
            return new TestAlbum("Troublegum","Therapy?");
        }
    }
}
