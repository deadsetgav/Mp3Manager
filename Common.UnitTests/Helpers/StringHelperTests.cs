using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UnitTests.Helpers
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void StringHelper_SameString_DifferentCase_Match()
        {
            // Act
            var result = StringHelper.StringsCloselyMatch_IgnoreCase("first", "FIRST");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StringHelper_DifferentString_DifferentCase_DontMatch()
        {
            // Act
            var result = StringHelper.StringsCloselyMatch_IgnoreCase("second", "FIRST");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StringHelper_SimilarString_DifferentCase_Match()
        {
            // Act
            var result = StringHelper.StringsCloselyMatch_IgnoreCase("firsty", "FIRST");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StringHelper_SimilarString_DifferentCaseWithAlphaNumeric_Match()
        {
            // Act
            var result = StringHelper.StringsCloselyMatch_IgnoreCaseAndNonAlphaNumeric("01 - CHERUB ROCK", "Cherub Rock");

            // Assert
            Assert.IsTrue(result);
        }
    }
}
