using Common.Exceptions;
using Formatting.Abstract;
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
    public class StandardiseAlbumTitleTests
    {
        ITrackFormatter _formatter;

        [TestInitialize]
        public void Setup()
        {
            var troublegum = new TestAlbum("Troublegum", "Therapy?");
            _formatter = new StandardiseAlbumTitle(troublegum);
        }

        [TestMethod]
        public void TrackFormat_StandardiseAlbumTitle_SetsNullField()
        {
            // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01",
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("Troublegum", mp3.Album);
        }

        [TestMethod]
        public void TrackFormat_StandardiseAlbumTitle_ResetsArtistIfSimilar()
        {
            // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01",
                Artist = "therapy?",
                Album = "trouble gum"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("Troublegum", mp3.Album);
        }

        [TestMethod, ExpectedException(typeof(TrackFormatException))]
        public void TrackFormat_StandardiseAlbumTitle_WarnIfArtistDifferent()
        {
             // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01",
                Album = "Nurse"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("Nurse", mp3.Album);
        }
    }
}
