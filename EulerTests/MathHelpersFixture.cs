using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace EulerTests
{
    [TestClass]
    public class MathHelpersFixture
    {
        [TestMethod]
        public void TestFindAmicablePartnerBasic()
        {
            Assert.AreEqual(284ul, MathHelpers.GetAmicablePartner(220));
        }

        [TestMethod]
        public void TestFindAmicablePartnerNEgative()
        {
            Assert.AreEqual(0ul, MathHelpers.GetAmicablePartner(6));
        }

        [TestMethod]
        public void TestGetFactosDoesntIncludeSquareRootTwice()
        {
            Assert.AreEqual(3, MathHelpers.GetFactors(9).Count);
        }
    }
}
