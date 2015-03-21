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
    public class RemovePrecedingZerosFromTrackNumberTests
    {
        ITrackFormatter _formatter;

        [TestInitialize]
        public void Setup()
        {
            _formatter = new RemovePrecedingZerosFromTrackNumber();
        }

        [TestMethod]
        public void TrackFormat_RemovePreceedingZerosFromTrackNumber_RemovesZeros()
        {
            // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "01"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("1", mp3.Track);
            Assert.AreEqual("01 - Knives", mp3.Title);
        }

        [TestMethod]
        public void TrackFormat_RemovePreceedingZerosFromTrackNumber_IgnoresTrackWithNoZero()
        {
            // Arrange
            var mp3 = new TestTrack()
            {
                Title = "01 - Knives",
                Track = "1"
            };

            // Act
            _formatter.Format(mp3);

            // Assert
            Assert.AreEqual("1", mp3.Track);
            Assert.AreEqual("01 - Knives", mp3.Title);
        }
    }
}
