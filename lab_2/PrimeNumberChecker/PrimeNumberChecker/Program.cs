using System;
using PrimeNumberLib;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            bool isPrime = PrimeChecker.IsPrime(number);
            Console.WriteLine(isPrime);
            Environment.Exit(0); // Успішний код виходу
        }
        else
        {
            Console.Error.WriteLine("Invalid input. Please enter a valid integer.");
            Environment.Exit(1); // Помилковий код виходу
        }
    }
}
