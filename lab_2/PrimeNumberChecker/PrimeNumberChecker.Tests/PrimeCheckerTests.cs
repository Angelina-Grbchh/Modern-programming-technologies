using NUnit.Framework;
using PrimeNumberLib;
using System;
using System.Diagnostics;
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

        // Тестуємо, що правильне число повертає код 0
        [Test]
        public void Program_ReturnsExitCode0_OnValidPrimeInput()
        {
            int exitCode = RunProgramWithInput("17", out _, out _);
            Assert.That(exitCode, Is.EqualTo(0));
        }

        // Тестуємо, що неправильне число теж дає код 0 (оскільки це не помилка)
        [Test]
        public void Program_ReturnsExitCode0_OnValidNonPrimeInput()
        {
            int exitCode = RunProgramWithInput("18", out _, out _);
            Assert.That(exitCode, Is.EqualTo(0));
        }

        // Тестуємо, що неправильний ввід повертає ненульовий код виходу
        [Test]
        public void Program_ReturnsNonZeroExitCode_OnInvalidInput()
        {
            int exitCode = RunProgramWithInput("abc", out _, out string error);
            Assert.That(exitCode, Is.Not.EqualTo(0));
            Assert.That(error, Does.Contain("Invalid input"));
        }

        // Тестуємо, що вхідні дані правильно зчитуються
        [Test]
        public void Program_ReadsFromStdin()
        {
            int exitCode = RunProgramWithInput("19", out string output, out _);
            Assert.That(output.Trim(), Is.EqualTo("True"));
            Assert.That(exitCode, Is.EqualTo(0));
        }

        // Тестуємо, що результат пишеться в stdout
        [Test]
        public void Program_WritesResultToStdout()
        {
            int exitCode = RunProgramWithInput("20", out string output, out _);
            Assert.That(output.Trim(), Is.EqualTo("False"));
            Assert.That(exitCode, Is.EqualTo(0));
        }

        // Тестуємо, що помилки пишуться в stderr
        [Test]
        public void Program_WritesErrorsToStderr()
        {
            int exitCode = RunProgramWithInput("xyz", out _, out string error);
            Assert.That(error, Does.Contain("Invalid input"));
            Assert.That(exitCode, Is.Not.EqualTo(0));
        }

        // Функція для запуску програми з заданим вхідним значенням
        private int RunProgramWithInput(string input, out string output, out string error)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run --project ../PrimeNumberChecker/PrimeNumberChecker.csproj",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                using (StreamWriter sw = process.StandardInput)
                {
                    sw.WriteLine(input);
                }

                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                return process.ExitCode;
            }
        }
    }
}
