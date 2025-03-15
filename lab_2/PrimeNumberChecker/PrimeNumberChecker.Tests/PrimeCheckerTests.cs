using NUnit.Framework;
using PrimeNumberLib;

namespace PrimeNumberChecker.Tests
{
    [TestFixture]
    public class PrimeCheckerTests
    {
        [Test]
        public void IsPrime_ReturnsTrue_ForPrimeNumber()
        {
            Assert.That(PrimeChecker.IsPrime(17), Is.True);
        }

        [Test]
        public void IsPrime_ReturnsFalse_ForNonPrimeNumber()
        {
            Assert.That(PrimeChecker.IsPrime(18), Is.False);
        }

        [Test]
        public void IsPrime_ReturnsFalse_ForNegativeNumber()
        {
            Assert.That(PrimeChecker.IsPrime(-5), Is.False);
        }

        [Test]
        public void IsPrime_ReturnsFalse_ForZeroAndOne()
        {
            Assert.That(PrimeChecker.IsPrime(0), Is.False);
            Assert.That(PrimeChecker.IsPrime(1), Is.False);
        }
    }
}
