using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace EulerTests
{
    [TestClass]
    public class TextHelpersFixture
    {
        [TestMethod]
        public void TestGetLetterScore()
        {
            Assert.AreEqual(1u, TextHelpers.GetLetterScore('a'));
            Assert.AreEqual(1u, TextHelpers.GetLetterScore('A'));
            Assert.AreEqual(26u, TextHelpers.GetLetterScore('z'));
            Assert.AreEqual(26u, TextHelpers.GetLetterScore('Z'));
        }

        [TestMethod]
        public void TestGetWordScore()
        {
            const uint expected = (26u*27u)/2u; //Formula for the sum of all numbers 1-26  (n*(n+1)/2)
            Assert.AreEqual(expected, TextHelpers.GetWordScore("abcdefghijklmnopqrstuvwxyz"));
            Assert.AreEqual(expected, TextHelpers.GetWordScore("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
        }
    }
}