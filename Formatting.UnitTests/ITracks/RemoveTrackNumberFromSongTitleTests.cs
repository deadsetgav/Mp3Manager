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
    public class RemoveTrackNumberFromSongTitleTests
    {
        RemoveTrackNumberFromSongTitle _formatter;

        [TestInitialize]
        public void Setup()
        {
            _formatter = new RemoveTrackNumberFromSongTitle();
        }

        [TestMethod]
        public void TrackFormat_RemoveTrackNumberFromSongTitle_RemovesTrackNo()
        {
            // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("Knives", mp3.Title);
        }

        [TestMethod]
        public void TrackFormat_RemoveTrackNumberFromSongTitle_IgnoresSongsWithNoPrecedingTrackNo()
        {
            // Arrange
            var mp3 = new TestTrack()
            {
                Title = "99 Red Baloons"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("99 Red Baloons", mp3.Title);
        }
    }
}
