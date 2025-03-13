using System;

public class Program
{
    static int Main(string[] args)
    {
        try
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int number))
            {
                Console.Error.WriteLine("Помилка: Введене значення не є цілим числом.");
                return 1; 
            }

            bool isPrime = IsPrime(number);
            Console.WriteLine(isPrime);
            return 0; 
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Помилка виконання: {ex.Message}");
            return 2; 
        }
    }

    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
