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
    public class StandardiseArtistTests
    {
        ITrackFormatter _formatter;

        [TestInitialize]
        public void Setup()
        {
            var troublegum = new TestAlbum("Troublegum", "Therapy?");
            _formatter = new StandardiseArtist(troublegum);
        }

        [TestMethod]
        public void TrackFormat_StandardiseArtist_SetsNullField()
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
            Assert.AreEqual("Therapy?", mp3.Artist);
        }

        [TestMethod]
        public void TrackFormat_StandardiseArtist_ResetsArtistIfSimilar()
        {
            // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01",
                Artist = "therapy?"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("Therapy?", mp3.Artist);
        }

        [TestMethod, ExpectedException(typeof(TrackFormatException))]
        public void TrackFormat_StandardiseArtist_WarnIfArtistDifferent()
        {
             // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01",
                Artist = "Terrorvision"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("Therapy?", mp3.Artist);
        }
    }
}
