using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UnitTests.Models
{
    [TestClass]
    public class ArtistTests
    {
        [TestMethod]
        public void WithArtist_CanCreate()
        {
            // Arrage
            var testName = "Faith No More";

            // Act
            var artist = new Artist(testName);

            // Assert
            Assert.AreEqual(testName, artist.Name);
        }
    }
}
