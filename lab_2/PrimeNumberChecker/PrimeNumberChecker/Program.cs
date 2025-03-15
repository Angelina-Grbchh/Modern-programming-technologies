using System;

namespace PrimeNumberChecker
{
    public class Program
    {
        public static int Main()
        {
            try
            {
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.Error.WriteLine("No input provided.");
                    return 1;
                }

                if (!int.TryParse(input, out int number))
                {
                    Console.Error.WriteLine("Invalid input. Please enter a valid integer.");
                    return 1;
                }

                bool result = PrimeNumberLib.PrimeChecker.IsPrime(number);
                Console.Out.WriteLine(result);
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
                return 1;
            }
        }
    }
}
