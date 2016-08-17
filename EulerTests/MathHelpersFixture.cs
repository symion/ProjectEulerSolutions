using System;
using System.Linq;
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
        public void TestFindAmicablePartnerNegative()
        {
            Assert.AreEqual(0ul, MathHelpers.GetAmicablePartner(6));
        }

        [TestMethod]
        public void TestGetFactorsDoesntIncludeSquareRootTwice()
        {
            Assert.AreEqual(3, MathHelpers.GetFactors(9).Count);
        }

        [TestMethod]
        public void TestGetPerfectionRating()
        {
            Assert.AreEqual(MathHelpers.PerfectionRating.Deficient, MathHelpers.GetPerfectionRating(9));
            Assert.AreEqual(MathHelpers.PerfectionRating.Perfect, MathHelpers.GetPerfectionRating(6));
            Assert.AreEqual(MathHelpers.PerfectionRating.Abundant, MathHelpers.GetPerfectionRating(12));
        }

        [TestMethod]
        public void TestSumOfProperFactors()
        {
            for (var x = 2ul; x <= 1000; x++)
            {
                Assert.AreEqual(
                    MathHelpers.GetFactors(x).Where(f => f < x).Aggregate(0ul, (current, total) => current + total),
                    MathHelpers.SumOfProperFactors(x));
            }
        }
    }
}
