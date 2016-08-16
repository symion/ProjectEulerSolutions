using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace EulerTests
{
    [TestClass]
    public class MyBigIntFixture
    {
        [TestMethod]
        public void TestIsUlong()
        {
            var num = new MyBigInt(ulong.MaxValue);
            Assert.IsTrue(num.FitsInULong());
            var decimalNum = (decimal)ulong.MaxValue + 1;
            num = new MyBigInt(decimalNum);
            Assert.IsFalse(num.FitsInULong());
            decimalNum -= 1;
            decimalNum *= 10;
            num = new MyBigInt(decimalNum);
            Assert.IsFalse(num.FitsInULong());
            num = new MyBigInt(1);
            Assert.IsTrue(num.FitsInULong());
        }

        [TestMethod]
        public void TestConvertToULong()
        {
            Assert.AreEqual(ulong.MaxValue, new MyBigInt(ulong.MaxValue).Cast<ulong>());
        }

        [TestMethod]
        public void TestAdding()
        {
            var random = new Random();
            for (var index = 0; index < 100000; index++)
            {
                var num1 = (ulong) random.Next();
                var num2 = (ulong) random.Next();

                var big1 = new MyBigInt(num1);
                big1.Add(new MyBigInt(num2));

                Assert.AreEqual(num1 + num2, big1.Cast<ulong>());
            }
        }

        [TestMethod]
        public void TestCreatFromMyBigInt()
        {
            var first = new MyBigInt(ulong.MaxValue);
            var second = new MyBigInt(first);

            first.Add(new MyBigInt(1000000));

            Assert.AreEqual(ulong.MaxValue, second.Cast<ulong>());
        }

        [TestMethod]
        public void TestFactorial()
        {
            var num = new MyBigInt(15);
            num.Factorial();
            Assert.AreEqual(1307674368000ul, num.Cast<ulong>());
        }
    }
}
