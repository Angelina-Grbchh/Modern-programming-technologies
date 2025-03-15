using System;

namespace PrimeNumberChecker
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.Error.WriteLine("No input provided.");
                    Environment.Exit(1);
                }

                if (!int.TryParse(input, out int number))
                {
                    Console.Error.WriteLine("Invalid input. Please enter a valid integer.");
                    Environment.Exit(1);
                }

                bool result = PrimeNumberLib.PrimeChecker.IsPrime(number);
                Console.WriteLine(result);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
