using NUnit.Framework;
using PrimeNumberLib;
using PrimeNumberChecker;
using System;
using System.IO;

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

        [Test]
        public void Main_ReturnsZero_OnValidPrimeInput()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("17");
            Console.SetIn(input);

            int exitCode = Program.Main();

            Assert.That(exitCode, Is.EqualTo(0));
            Assert.That(output.ToString().Trim(), Is.EqualTo("True"));
        }

        [Test]
        public void Main_ReturnsZero_OnValidNonPrimeInput()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("18");
            Console.SetIn(input);

            int exitCode = Program.Main();

            Assert.That(exitCode, Is.EqualTo(0));
            Assert.That(output.ToString().Trim(), Is.EqualTo("False"));
        }

        [Test]
        public void Main_ReturnsNonZero_OnInvalidInput()
        {
            var errorOutput = new StringWriter();
            Console.SetError(errorOutput);
            var input = new StringReader("abc");
            Console.SetIn(input);

            int exitCode = Program.Main();

            Assert.That(exitCode, Is.Not.EqualTo(0));
            Assert.That(errorOutput.ToString(), Does.Contain("Invalid input"));
        }

        [Test]
        public void Main_WritesErrorsToStderr()
        {
            var errorOutput = new StringWriter();
            Console.SetError(errorOutput);
            var input = new StringReader("");
            Console.SetIn(input);

            int exitCode = Program.Main();

            Assert.That(exitCode, Is.Not.EqualTo(0));
            Assert.That(errorOutput.ToString(), Does.Contain("No input provided."));
        }

        [Test]
        public void Main_ReadsInputFromStdin()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("19");
            Console.SetIn(input);

            int exitCode = Program.Main();

            Assert.That(exitCode, Is.EqualTo(0));
            Assert.That(output.ToString().Trim(), Is.EqualTo("True"));
        }
    }
}
