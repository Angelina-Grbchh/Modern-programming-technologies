
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberChecker;

namespace PrimeNumberChecker.Tests
{
    [TestClass]
    public class PrimeNumberTests
    {
        [TestMethod]
        public void TestPrimeNumbers()
        {
            Assert.IsTrue(Program.IsPrime(17));
            Assert.IsTrue(Program.IsPrime(2));
            Assert.IsTrue(Program.IsPrime(3));
        }

        [TestMethod]
        public void TestNonPrimeNumbers()
        {
            Assert.IsFalse(Program.IsPrime(4));
            Assert.IsFalse(Program.IsPrime(1));
            Assert.IsFalse(Program.IsPrime(0));
        }

        [TestMethod]
        public void TestNegativeNumbers()
        {
            Assert.IsFalse(Program.IsPrime(-5));
            Assert.IsFalse(Program.IsPrime(-2));
        }
    }
}
